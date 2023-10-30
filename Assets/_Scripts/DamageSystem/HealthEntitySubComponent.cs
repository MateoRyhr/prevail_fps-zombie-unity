using UnityEngine;

public class HealthEntitySubComponent : MonoBehaviour, IDamageTaker
{
    [SerializeField] private FloatVariable _damageMultiplier;
    [SerializeField] private HealthEntity _entityHealth;
    public HealthEntity HealthEntity { get => _entityHealth; }
    
    private float _damageMultiplierValue;

    private void Awake()
    {
        _damageMultiplierValue = 1f;
        if(_damageMultiplier) _damageMultiplierValue = _damageMultiplier.Value;
        // _entityHealth = GetComponentInParent<HealthEntity>();
    }

    public void TakeDamage(float damage)
    {
        _entityHealth.TakeDamage(damage * _damageMultiplierValue);
    }
}
