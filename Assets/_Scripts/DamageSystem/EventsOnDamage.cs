using UnityEngine;
using UnityEngine.Events;

public class EventsOnDamage : MonoBehaviour
{
    private ICollision _collisionGetter;

    public UnityEvent OnKill;
    public UnityEvent OnDamage;

    private void Awake() => _collisionGetter = GetComponent<ICollision>();

    public void CheckDamageEvents()
    {
        Collision collision = _collisionGetter.Collision;
        var healthComponent = collision.gameObject.GetComponent<HealthEntitySubComponent>();
        if(healthComponent == null) return;

        if(healthComponent.HealthEntity.Health.Value > 0)
            OnDamage?.Invoke();
        if(healthComponent.HealthEntity.LastDamageKilledIt)
        {
            OnDamage?.Invoke();
            OnKill?.Invoke();
        }
    }
}