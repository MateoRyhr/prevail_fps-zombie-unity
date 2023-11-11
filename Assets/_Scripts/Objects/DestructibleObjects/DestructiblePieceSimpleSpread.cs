using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestructiblePieceSimpleSpread : MonoBehaviour, ICollision, IDamageTaker
{
    // [SerializeField] private bool debug;

    [Tooltip("The layer of the object which this piece is attached")]
    [SerializeField] private LayerMask _connectionLayerMask;
    [SerializeField] private LayerMask _pieceLayerMask;
    [SerializeField] private FloatVariable _checkPieceRadio;
    [SerializeField] private Rigidbody _rigidbodyPrefab;

    [SerializeField] private bool _destroyOnHit = true;
    [SerializeField] private int _propagationRounds = 1;

    public Collision Collision { get; set; }
    
    private Mesh _mesh;
    private Collider _collider;
    private ForceReceiver _forceReceiver;

    public bool Disconnected { get; private set; }

    private List<DestructiblePieceSimpleSpread> _neighbours;
    
    public UnityEvent OnImpact;
    public UnityEvent OnDisconnect;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _mesh = GetComponent<MeshFilter>().mesh;
        _forceReceiver = GetComponent<ForceReceiver>();
        _neighbours = new List<DestructiblePieceSimpleSpread>();
    }

    private void Start()
    {
        Disconnected = false;
        _neighbours = GetNeighbours();
    }

    public void TakeDamage(float damage)
    {
        DestroyPiece();
    }

    public void DestroyPiece()
    {
        OnImpact?.Invoke();
        DisconnectPiece();
        PropagateDestruction(-1);
        if(_destroyOnHit)
            Destroy(gameObject);
    }

    public List<DestructiblePieceSimpleSpread> GetNeighbours()
    {
        List<DestructiblePieceSimpleSpread> neighbours = new List<DestructiblePieceSimpleSpread>();
        for(int i = 1;i < _mesh.vertices.Length; i++) //for each vertice
        {
            Collider[] neighboursToCheck = Physics.OverlapSphere(transform.TransformPoint(_mesh.vertices[i]),_checkPieceRadio.Value,_pieceLayerMask);
            if(neighboursToCheck.Length > 0)
            {
                for (int j = 0; j < neighboursToCheck.Length; j++)
                {
                    DestructiblePieceSimpleSpread neighbour = neighboursToCheck[j].GetComponent<DestructiblePieceSimpleSpread>();
                    if(neighbour != this && !neighbours.Contains(neighbour))
                        neighbours.Add(neighbour);
                }
            } 
        }
        return neighbours;
    }

    public void DisconnectPiece()
    {
        if(Disconnected) return;
        Disconnected = true;
        OnDisconnect?.Invoke();
        transform.SetParent(null);
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.mass = _rigidbodyPrefab.mass;
        rigidbody.drag = _rigidbodyPrefab.drag;
        rigidbody.angularDrag = _rigidbodyPrefab.angularDrag;
        _forceReceiver.SetRigidbody(rigidbody);
    }

    void PropagateDestruction(int roundOfPropagation)
    {
        roundOfPropagation++;
        // Debug.Log($"Round propagation: {roundOfPropagation}");
        foreach(DestructiblePieceSimpleSpread neighbour in _neighbours)
        {
            if(neighbour && !neighbour.Disconnected)
            {
                // Debug.Log($"Disconnected status of neighbour checked: {neighbour.Disconnected}");
                if(roundOfPropagation < _propagationRounds)
                {
                    neighbour.DisconnectPiece();
                    neighbour.ReceiveForce(_forceReceiver.ForceReceived,transform.position);
                    neighbour.PropagateDestruction(roundOfPropagation);
                }
                else
                {
                    neighbour.InvokeScaledDeltaTime(() => CheckFallOfRemainingChunkOfAPiece(neighbour),Time.deltaTime);
                }
            }
        }
        _neighbours.Clear();
    }

    public bool CheckChunkConnection(List<DestructiblePieceSimpleSpread> chunk,out List<DestructiblePieceSimpleSpread> piecesChecked)
    {
        if(!chunk.Contains(this)) chunk.Add(this);
        piecesChecked = chunk;
        if(this.IsWallConnected()) return true;
        foreach(DestructiblePieceSimpleSpread neighbour in _neighbours)
        {
            if(neighbour && !neighbour.Disconnected)
                if(!chunk.Contains(neighbour))
                {
                    if(neighbour.CheckChunkConnection(chunk,out piecesChecked)) return true;
                }
        }
        return false;
    }

    void CheckFallOfRemainingChunkOfAPiece(DestructiblePieceSimpleSpread piece)
    {
        List<DestructiblePieceSimpleSpread> chunk = new List<DestructiblePieceSimpleSpread>();
        bool isChunkConnected = piece.CheckChunkConnection(chunk,out chunk);
        // Debug.Log($"Chunk count: {chunk.Count}");
        if(!isChunkConnected)
            foreach (DestructiblePieceSimpleSpread pieceOfChunk in chunk)
            {
                pieceOfChunk.DisconnectPiece();
            }
    }

    bool IsWallConnected()
    {
        for(int i = 1;i < _mesh.vertices.Length; i++)
        {
            if(Physics.OverlapSphere(transform.TransformPoint(_mesh.vertices[i]),_checkPieceRadio.Value,_connectionLayerMask).Length > 0)
                return true;
        }
        return false;
    }

    void ReceiveForce(Vector3 force, Vector3 point)
    {
        this.Invoke(() => {
            _forceReceiver.ReceiveForceAtPoint(force,point);
        },Time.fixedDeltaTime);
    }

    //For Debug

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.green;
    //     if(!_mesh) return;
    //     for(int i = 0;i < _mesh.vertices.Length; i++)
    //     {
    //         Gizmos.DrawSphere(
    //             transform.TransformPoint(_mesh.vertices[i]),
    //             _checkPieceRadio.Value);
    //     }
    // }
}
