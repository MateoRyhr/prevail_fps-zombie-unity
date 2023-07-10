using UnityEngine;
using TMPro;

public class AmmoOnHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] Equipper _weaponEquipper;
    [SerializeField] ObjectUser _weaponUser;
    [SerializeField] AmmoCounter _ammoCounter;

    Usable _usable;

    private void Awake()
    {
        _ammoCounter.OnWeaponChange.AddListener(() => {
            UpdateWeapon();
            UpdateAmmo();
            _usable.OnUse.AddListener(UpdateAmmo);
        });
        // _ammoCounter.OnAmmunitionCollected.AddListener(() => UpdateAmmo());
        _ammoCounter.OnAmmoChange.AddListener(UpdateAmmo);
    }

    public void UpdateAmmo()
    {
        if(_usable is RangedWeapon)
        {
            RangedWeapon gun = (RangedWeapon) _usable;
            _text.text = $"{gun.CurrentAmmo} / {_ammoCounter.AmountsCounter.Amounts[(int)gun.RangedWeaponData.ammoType]}";
        }
        else
        {
            _text.text = $"-";
        }
    }

    void UpdateWeapon()
    {
        _usable = _weaponUser.Usable;
    }
}
