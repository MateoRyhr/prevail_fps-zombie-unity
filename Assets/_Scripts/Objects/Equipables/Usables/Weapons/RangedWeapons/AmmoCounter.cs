using UnityEngine;
using UnityEngine.Events;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private int[] _initialAmounts;
    [SerializeField] private Equipper _weaponEquipper;

    private RangedWeapon _rangedWeapon;
    public AmountOfTypesCounter AmountsCounter;
    public int CurrentAmmoType { get => (int)_rangedWeapon.RangedWeaponData.ammoType; }
    
    public UnityEvent OnNoAmmo;
    public UnityEvent OnAmmoChange;
    public UnityEvent OnWeaponChange;

    private void Awake()
    {
        AmountsCounter = new AmountOfTypesCounter(new AmmoType(),_initialAmounts);
    }

    public void UpdateWeapon()
    {
        if(_weaponEquipper.Equipped is RangedWeapon)
            _rangedWeapon = (RangedWeapon)_weaponEquipper.Equipped;
        else
            _rangedWeapon = null;
        OnWeaponChange?.Invoke();
    }

    public void Reload()
    {
        if(!_rangedWeapon || _rangedWeapon.IsReloading) return;
        int ammoAvailable = AmountsCounter.Amounts[CurrentAmmoType];
        if(ammoAvailable <= 0)
        {
            OnNoAmmo?.Invoke();
            return;
        }
        _rangedWeapon.Reload(ammoAvailable,SubstractAmmo);
    }

    public void SubstractAmmo(int value)
    {
        AmountsCounter.Amounts[CurrentAmmoType] -= value;
        OnAmmoChange?.Invoke();
    }

    public void AddAmmo(int value)
    {
        AmountsCounter.Amounts[CurrentAmmoType] += value;
        OnAmmoChange?.Invoke();
    }
}

