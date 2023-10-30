using UnityEngine;
using UnityEngine.Events;

public class EventAfterTime : MonoBehaviour
{
    public UnityEvent Event;

    public void RaiseEvent(float delay) => this.Invoke(() => Event?.Invoke(),delay);
}
