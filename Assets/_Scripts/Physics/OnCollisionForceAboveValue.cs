using UnityEngine;
using UnityEngine.Events;

public class OnCollisionForceAboveValue : MonoBehaviour
{
    [SerializeField] private FloatVariable _value;
    [SerializeField] private int[] _layers;

    public UnityEvent Event;

    private void OnCollisionEnter(Collision collision)
    {
        foreach (var layer in _layers)
        {
            if(collision.gameObject.layer == layer)
                if(collision.relativeVelocity.magnitude > _value.Value)
                    Event?.Invoke();
        }
    }
}
