using UnityEngine;
using UnityEngine.Events;

public class EventInARangeOfTime : MonoBehaviour
{
    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;

    public UnityEvent OnEvent;

    bool _canInvokeEvent;

    public void InvokeEvent()
    {
        float timeToInvoke = Random.Range(_minTime,_maxTime);
        this.Invoke(() => OnEvent?.Invoke(),timeToInvoke);
    }

    public void StartLoopInvoke()
    {
        _canInvokeEvent = true;
        // float timeToInvoke = Random.Range(_maxTime,_maxTime);
        LoopInvokeEvent(0f);
    }

    public void StopLoopInvoke()
    {
        _canInvokeEvent = false;
        StopAllCoroutines();
    }

    void LoopInvokeEvent(float timeToInvoke)
    {
        this.Invoke(() => 
        {
            OnEvent?.Invoke();
            if(_canInvokeEvent)
            {
                float nextEventTimeToInvoke = Random.Range(_minTime,_maxTime);
                LoopInvokeEvent(nextEventTimeToInvoke);
            }
        }
        ,timeToInvoke);
    }
}
