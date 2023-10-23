using System.Collections.Generic;
using UnityEngine;

// using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.HighDefinition;

[CreateAssetMenu(fileName = "DecalOnCollision", menuName = "Decal/DecalOnCollision")]
public class DecalOnCollision : ScriptableObject
{
    public DecalProjector _decalEffect;
    [Tooltip("Distance from the decal to the collider, maybe need to be small than Projection Depth")] public float _distanceFromCollision;
    public Vector2[] Variations;
    public int MaxAmount;

    private Collision _collision;
    private int _currentDecalAmount;

    private List<DecalProjector> _decalPool;

    private void OnEnable()
    {
        _currentDecalAmount = 0;
        _decalPool = new List<DecalProjector>();
    }

    public void PrintDecal(Collision collision)
    {
        _collision = collision;
        DecalProjector decal = GetDecal();
        SetDecal(decal);
    }

    private DecalProjector CreateDecal()
    {
        DecalProjector decal = Instantiate( 
            _decalEffect,
            Vector3.zero,
            Quaternion.identity
        );
        return decal;
    }

    private DecalProjector GetDecal()
    {
        if(_currentDecalAmount < MaxAmount)
        {
            _decalPool.Add(CreateDecal());
            _currentDecalAmount++;
        }
        else
        {
            DecalProjector decal = _decalPool[0];
            _decalPool.Remove(decal);
            _decalPool.Add(decal);
        }
        return _decalPool[_decalPool.Count-1];
    }

    private void SetDecal(DecalProjector decal)
    {
        decal.gameObject.SetActive(true);
        SetInSpace(decal);
        SetRandomTexture(decal);
    }

    void SetRandomTexture(DecalProjector decal) => decal.uvBias = Variations[Random.Range(0,Variations.Length)];

    void SetInSpace(DecalProjector decal)
    {
        Vector3 position = _collision.GetContact(0).point + _collision.GetContact(0).normal * _distanceFromCollision;
        Quaternion rotation = Quaternion.LookRotation(_collision.GetContact(0).normal*-1);
        decal.transform.SetPositionAndRotation(position,rotation);
        decal.transform.Rotate(new Vector3(0,0,Random.Range(0f,360f)),Space.Self);
        decal.transform.parent = _collision.collider.transform;
    }
}
