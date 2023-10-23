using UnityEngine;

public class ForceApplierOnCollision : ForceApplier
{
    private ICollision _collisionGetter;
    [SerializeField] Vector3 _forceWithLocalDirection;

    private void Awake()
    {
        _collisionGetter = GetComponent<ICollision>();
    }

    public void ApplyForceAtPoint(bool useLocalDirection)
    {
        if(!useLocalDirection)
            ApplyForceAtPoint(_collisionGetter.Collision,Time.fixedDeltaTime,true);
        else
            ApplyForceAtPoint(_collisionGetter.Collision,transform.TransformDirection(_forceWithLocalDirection),Time.fixedDeltaTime,true);
    }

    public void ApplyForce(bool useLocalDirection)
    {
        if(!useLocalDirection)
            ApplyForce(_collisionGetter.Collision,Time.fixedDeltaTime,true);
        else
            ApplyForce(_collisionGetter.Collision,transform.TransformDirection(_forceWithLocalDirection),Time.fixedDeltaTime,true);
    }
}
