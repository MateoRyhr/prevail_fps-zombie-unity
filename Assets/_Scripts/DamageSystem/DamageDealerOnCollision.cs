using UnityEngine;

public class DamageDealerOnCollision : MonoBehaviour, IDamageDealer
{
    public float DamageAmount { get; set; }
    private IDamageTaker _damageable;

    public void DealDamage()
    {
        GetDamageable();
        if(_damageable == null || !TakeDamageCondition()) return;
        DamageAmount = GetComponent<IFloat>().Value;
        _damageable.TakeDamage(DamageAmount);
    }

    public bool TakeDamageCondition() => true;

    void GetDamageable()
    {
        _damageable = GetComponent<ICollision>().Collision.gameObject.GetComponent<IDamageTaker>();
    }
}