using UnityEngine;

public class SurfaceGetterOnCollision : SurfaceGetter
{
    private ICollision _collisionGetter;

    private void Awake()
    {
        _collisionGetter = GetComponent<ICollision>();
    }

    public void GetSurface()
    {
        Collision collision = _collisionGetter.Collision;
        Surface = collision.collider.GetComponent<Surface>();
    }
}
