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

    private Pool<DecalProjector> _pool;

    public void PrintDecal(Collision collision)
    {
        _collision = collision;
        DecalProjector decal = _pool.GetObject();
        // DecalProjector decal = GetDecal();
        // SetDecal(decal);
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

    public void Init()
    {
        _pool = new Pool<DecalProjector>(CreateDecal,SetDecal,MaxAmount);
    }
}
