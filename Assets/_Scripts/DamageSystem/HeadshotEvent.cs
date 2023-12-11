using UnityEngine;
using UnityEngine.Events;

public class HeadshotEvent : MonoBehaviour
{
    [SerializeField] private string _headshotTag = "head";

    private ICollision _collisionGetter;

    public UnityEvent OnHeadshotKill;
    public UnityEvent OnHeadshot;

    private void Awake() => _collisionGetter = GetComponent<ICollision>();

    public void CheckHeadshotEvents()
    {
        Collision collision = _collisionGetter.Collision;
        var healthComponent = collision.gameObject.GetComponent<HealthEntitySubComponent>();
        if(healthComponent == null) return;
        bool headshot = collision.gameObject.tag == _headshotTag;

        if(headshot)
        {
            if(healthComponent.HealthEntity.Health.Value > 0)
            {
                OnHeadshot?.Invoke();
            }
            if(healthComponent.HealthEntity.LastDamageKilledIt)
            {
                OnHeadshot?.Invoke();
                OnHeadshotKill?.Invoke();
            }
        }
    }
}