using UnityEngine;
using UnityEngine.Events;

public class MeleeWeaponCollidable : MonoBehaviour, ICollision, IFloat
{
    [SerializeField] private LayerMask _impactableLayers;
    // [SerializeField] private int[] _impactableLayers;
    
    public float Damage { get; set; }

    private Collision _collision;
    public Collision Collision { get => _collision; set => _collision = value; }
    public float Value { get => Damage; set => Damage = value; }

    private bool hasCollided;

    public UnityEvent OnImpact;

    private void Awake()
    {
        hasCollided = false;
        Destroy(gameObject,Time.fixedDeltaTime*4);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(hasCollided || !IsImpactable(collision.collider.gameObject)) return;
        hasCollided = true;
        _collision = collision;
        OnImpact?.Invoke();
        Vector3 contactPoint = collision.collider.ClosestPoint(collision.GetContact(0).point);
        ICollision impactedCollisionGetter = collision.collider.GetComponent<ICollision>();
        if(impactedCollisionGetter != null) impactedCollisionGetter.Collision = collision;
        IVector3 impactedVectorGetter = collision.collider.GetComponent<IVector3>();
        if(impactedVectorGetter != null) impactedVectorGetter.Value = contactPoint;
        // IDamageTaker damageTaker = collision.collider.GetComponent<IDamageTaker>();
        // if(damageTaker != null)
        // {
        //     damageTaker.TakeDamage(Damage,true);
        // }
        Destroy(gameObject);
    }

    public bool IsImpactable(GameObject other) => LayerUtil.LayerContains(_impactableLayers,other.layer);
    // {

    //     foreach (int impactableLayer in _impactableLayers)
    //     {
    //         if(other.layer == impactableLayer) return true;
    //     }
    //     return false;
    // }
}
