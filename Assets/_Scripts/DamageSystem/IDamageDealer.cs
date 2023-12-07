using UnityEngine;

public interface IDamageDealer
{
    public float DamageAmount { get; set; }
    public abstract void DealDamage();
    // public abstract bool TakeDamageCondition();
}
