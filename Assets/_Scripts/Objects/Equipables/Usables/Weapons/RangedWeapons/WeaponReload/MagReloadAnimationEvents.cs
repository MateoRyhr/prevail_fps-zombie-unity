using UnityEngine;
using UnityEngine.Events;

public class MagReloadAnimationEvents : MonoBehaviour
{
    [SerializeField] float _timeToTakeMag;
    [SerializeField] float _timeToPutMag;

    public UnityEvent OnTakeMag;
    public UnityEvent OnPutMag;

    public void InvokeMagReloadEvents()
    {
        this.Invoke(() => OnTakeMag?.Invoke(),_timeToTakeMag);
        this.Invoke(() => OnPutMag?.Invoke(),_timeToPutMag);
    }
}
