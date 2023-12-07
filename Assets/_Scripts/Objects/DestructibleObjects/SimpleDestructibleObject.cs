using UnityEngine;

public class SimpleDestructibleObject : MonoBehaviour, ICollision, IVector3
{
    [SerializeField] private GameObject[] _piecesOfTheDestroyed;
    [SerializeField] private ForceReceiver _forceReceiver;
    private Component[] _componentsToDesactive;

    public Collision Collision { get; set; }
    public Vector3 Vector { get; set; }

    private void Awake()
    {
        _componentsToDesactive = GetComponents<Component>();
    }

    public void DestroyObject(){
        foreach(Component component in _componentsToDesactive){
            if(!(component is Transform)) Destroy(component);
        }
        foreach (GameObject piece in _piecesOfTheDestroyed)
        {
            piece.SetActive(true);
            Vector3 force = _forceReceiver.ForceReceived / _piecesOfTheDestroyed.Length;
            // piece.GetComponent<ForceReceiver>().ReceiveForceAtPoint(force,Collision.GetContact(0).point);
            piece.GetComponent<ForceReceiver>().ReceiveForceAtPoint(force,Vector);
            piece.transform.SetParent(null);
        }
        Destroy(gameObject);
    }
}
