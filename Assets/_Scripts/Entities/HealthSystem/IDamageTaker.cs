using UnityEngine;

public interface IDamageTaker
{
    // public bool CanTakeDamage { get; }
    public abstract void TakeDamage(float damage,bool useDamageMultiplier);
}
