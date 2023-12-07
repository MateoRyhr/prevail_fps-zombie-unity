using UnityEngine;

public class DamageDealerOnCollision : MonoBehaviour, IDamageDealer
{
    [SerializeField] private LayerMask _damageableLayers;
    public float DamageAmount { get; set; }

    public void DealDamage()
    {
        GameObject damageTaker = GetComponent<ICollision>().Collision.gameObject;
        if(!IsDamageable(damageTaker)) return;
        IDamageTaker damageable = damageTaker.GetComponent<IDamageTaker>();
        if(damageable == null) return;
        DamageAmount = GetComponent<IFloat>().Value;
        damageable.TakeDamage(DamageAmount);
    }

    bool IsDamageable(GameObject other) => LayerUtil.LayerContains(_damageableLayers,other.layer);
}