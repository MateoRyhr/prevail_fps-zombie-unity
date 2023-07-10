using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour, IDamageDealer, ICollision
{
    [SerializeField] int _teamLayer;
    [SerializeField] Collider _collider;
    [SerializeField] Rigidbody _rigidbody;
    // [SerializeField] SurfaceGetter _surfaceGetter;
    
    public float DamageAmount { get => _damageAmount; set => _damageAmount = value; }
    private float _damageAmount;

    // public Vector3 Velocity { get; set; }
    // public Vector3 Rotation { get; set; }

    private Collision _collision;
    public Collision Collision { get => _collision; set => _collision = value; }

    private bool _hasAlreadyCollided;

    public UnityEvent OnImpact;

    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.isKinematic = true;
        _collision = collision;
        OnImpact?.Invoke();
        Vector3 contactPoint = collision.collider.ClosestPoint(transform.position);
        ICollision impactedCollisionGetter = collision.collider.GetComponent<ICollision>();
        if(impactedCollisionGetter != null) impactedCollisionGetter.Collision = collision;
        IVector3 impactedVectorGetter = collision.collider.GetComponent<IVector3>();
        if(impactedVectorGetter != null) impactedVectorGetter.Value = contactPoint;
        IDamageTaker damageTaker = collision.collider.GetComponent<IDamageTaker>();
        if(damageTaker != null)
        {
            if(TakeDamageCondition(collision.collider.gameObject))
                damageTaker.TakeDamage(DamageAmount,true);
            else
                damageTaker.TakeDamage(0f,true);
        }
        Destroy(gameObject);
        // if(_forceApplier) _forceApplier.ApplyForceAtPoint(collision,transform.forward,Time.fixedDeltaTime,true);
        // if(_surfaceGetter.Surface.SurfaceType != SurfaceType.Glass)
        // {
        //     Destroy(gameObject);
        // }
        // else
        // {
        //     this.Invoke(() =>
        //     {
        //         transform.rotation = Quaternion.Euler(Rotation.x,Rotation.y,Rotation.z);
        //         _rigidbody.isKinematic = false;
        //         _rigidbody.velocity = transform.forward * Velocity.magnitude;
        //     }
        //     ,Time.fixedDeltaTime);
        // }
    }

    public bool TakeDamageCondition(GameObject other)
    {
        return true;
    }
}
