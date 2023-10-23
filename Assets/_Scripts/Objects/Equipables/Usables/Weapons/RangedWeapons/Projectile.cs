using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour, ICollision, IFloat
{
    [SerializeField] Collider _collider;
    [SerializeField] Rigidbody _rigidbody;

    private Collision _collision;
    public Collision Collision { get => _collision; set => _collision = value; }

    public float Damage { get; set; }
    public float Value { get => Damage; set => Damage = value; }

    public bool HasAlreadyCollided { get; set; }

    public UnityEvent OnImpact;
    public UnityEvent OnDestroyAfterImpact;

    private void OnCollisionEnter(Collision collision)
    {
        if(HasAlreadyCollided) return;
        HasAlreadyCollided = true;
        _collision = collision;
        Vector3 contactPoint = collision.collider.ClosestPoint(transform.position);
        IVector3 impactedVectorGetter = collision.collider.GetComponent<IVector3>();
        if(impactedVectorGetter != null) impactedVectorGetter.Value = contactPoint;
        OnImpact?.Invoke();
        OnDestroyAfterImpact?.Invoke();
    }
}
