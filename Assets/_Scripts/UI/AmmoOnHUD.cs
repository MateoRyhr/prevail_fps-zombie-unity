using UnityEngine;
using TMPro;

public class AmmoOnHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] Equipper _weaponEquipper;
    [SerializeField] ObjectUser _weaponUser;
    [SerializeField] AmmoCounter _ammoCounter;

    private Usable _usable;
    private RangedWeapon _gun;

    bool _rangedWeapon;

    private void Awake() => _ammoCounter.OnAmmoChange.AddListener(UpdateAmmo);

    public void UpdateAmmo()
    {
        if(_rangedWeapon)
        {
            _text.text = $"{_gun.CurrentAmmo} / {_ammoCounter.AmountsCounter.Amounts[(int)_gun.RangedWeaponData.ammoType]}";
        }
        else
        {
            _text.text = $"-";
        }
    }

    public void UpdateWeapon()
    {
        _usable = _weaponUser.Usable;
        if(_usable is RangedWeapon)
        {
            _rangedWeapon = true;
            _gun = (RangedWeapon) _usable;
        }
        else
            _rangedWeapon = false;
        _usable.OnUse.AddListener(UpdateAmmo);
    }
}
