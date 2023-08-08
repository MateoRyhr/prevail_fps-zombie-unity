using UnityEngine;

public class MagReloadAnimationCaller : MonoBehaviour
{
    [SerializeField] GameObject _magOnHand;
    private MagReloadAnimationHandler _magReloadAnimationHandler;
    
    public void SetMagReloadAnimationHandler()
    {
        _magReloadAnimationHandler = GetComponentInParent<MagReloadAnimationHandler>();
    }

    public void PutOnHand()
    {
        _magReloadAnimationHandler.ShowMag(_magOnHand);
    }

    public void RemoveFromHand()
    {
        _magReloadAnimationHandler.HideMag();
    }
}