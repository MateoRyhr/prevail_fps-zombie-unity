using UnityEngine;
using UnityEngine.Events;

public class BuyerOfAmmo : MonoBehaviour
{
    [SerializeField] private AmmoCounter _ammoCounter;

    public UnityEvent OnBuyAmmo;

    public void BuyAmmo(int amuntOfAmmo)
    {
        _ammoCounter.AddAmmo(amuntOfAmmo);
        OnBuyAmmo?.Invoke();
    }
}
