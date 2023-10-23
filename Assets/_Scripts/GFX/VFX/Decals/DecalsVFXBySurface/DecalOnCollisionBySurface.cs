using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DecalOnCollisionBySurface : MonoBehaviour
{
    [SerializeField] private DecalOnCollision[] _decalBySurface;

    private SurfaceGetter _surfaceGetter;
    private ICollision _collisionGetter;

    private void Awake()
    {
        _surfaceGetter = GetComponent<SurfaceGetter>();
        _collisionGetter = GetComponent<ICollision>();
    }

    public void PrintDecalBySurface()
    {   
        if(_surfaceGetter.Surface != null)
            _decalBySurface[(int)_surfaceGetter.Surface.SurfaceType].PrintDecal(_collisionGetter.Collision);
    }
}