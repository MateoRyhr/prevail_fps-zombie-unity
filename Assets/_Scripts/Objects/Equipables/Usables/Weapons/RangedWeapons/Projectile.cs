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

    private bool _hasAlreadyCollided;

    public UnityEvent OnImpact;

    private void OnCollisionEnter(Collision collision)
    {
        if(_hasAlreadyCollided) return;
        _hasAlreadyCollided = true;
        _collision = collision;
        OnImpact?.Invoke();
        Vector3 contactPoint = collision.collider.ClosestPoint(transform.position);
        IVector3 impactedVectorGetter = collision.collider.GetComponent<IVector3>();
        if(impactedVectorGetter != null) impactedVectorGetter.Value = contactPoint;
        Destroy(gameObject);
    }
}
