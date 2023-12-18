using UnityEngine;
using UnityEngine.Events;

public class HealthEntity : MonoBehaviour, IDamageTaker
{
    [SerializeField] private FloatVariable _maxValue;
    [SerializeField] private float _startingValue;
    
    public bool HasBeenDestructed { get; set; }
    public bool LastDamageKilledIt { get; set; }
    
    public UnityEvent OnGetDamage;
    public UnityEvent OnGetHeal;
    public UnityEvent OnDestroy;

    public Amount Health;

    private void Awake()
    {
        Health = new Amount(_startingValue,0,_maxValue.Value);
        Health.OnSubstractToTheAmount = () => OnGetDamage?.Invoke();
        Health.OnAddToTheAmount = () => OnGetHeal?.Invoke();
        LastDamageKilledIt = false;
    }

    public void TakeDamage(float damage)
    {
        if(HasBeenDestructed)
        {
            LastDamageKilledIt = false;
            return;
        }
        Health.Substract(damage);
        if(Health.Value <= 0 )
        {
            Health.SetAmount(0);
            if(!HasBeenDestructed)
            {
                HasBeenDestructed = true;
                LastDamageKilledIt = true;
                OnDestroy?.Invoke();
            }
        }
    }
}
