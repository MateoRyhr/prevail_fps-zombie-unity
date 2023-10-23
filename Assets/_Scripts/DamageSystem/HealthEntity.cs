using UnityEngine;
using UnityEngine.Events;

public class HealthEntity : MonoBehaviour, IDamageTaker
{
    [SerializeField] private FloatVariable _maxValue;
    [SerializeField] private float _startingValue;
    
    private bool _hasBeenDestructed;

    public UnityEvent OnGetDamage;
    public UnityEvent OnGetHeal;
    public UnityEvent OnDestroy;

    public Amount Health;

    private void Awake()
    {
        Health = new Amount(_startingValue,_maxValue.Value);
        Health.OnSubstractToTheAmount = () => OnGetDamage?.Invoke();
        Health.OnAddToTheAmount = () => OnGetHeal?.Invoke();
    }

    public void TakeDamage(float damage)
    {
        if(_hasBeenDestructed) return;
        Health.Substract(damage);
        if(Health.Value <= 0 )
        {
            Health.SetAmount(0);
            if(!_hasBeenDestructed)
            {
                _hasBeenDestructed = true;
                OnDestroy?.Invoke();
            }
        }
    }
}
