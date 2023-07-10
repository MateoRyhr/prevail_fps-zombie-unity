using UnityEngine;

public class MagReloadAnimationCaller : MonoBehaviour
{
    [SerializeField] GameObject _magOnHand;
    [SerializeField] float _timeToTakeMag;
    [SerializeField] float _timeToPutMag;

    public void CallMagAnimation()
    {
        var magHandler = GetComponentInParent<MagReloadAnimationHandler>();
        Debug.Log($"{magHandler}");
        this.Invoke(() => magHandler.ShowMag(_magOnHand),_timeToTakeMag);
        this.Invoke(() => magHandler.HideMag(),_timeToPutMag);
    }
}