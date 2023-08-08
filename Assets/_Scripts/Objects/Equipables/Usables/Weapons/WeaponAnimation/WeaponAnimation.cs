using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    [SerializeField] private EntityRigConstraints _rigConstraints;
    [SerializeField] private Transform _weaponContainer;

    private Weapon _weapon;

    public void UpdateAnimation()
    {
        _weapon = _weaponContainer.GetComponentInChildren<Weapon>();
        if(_weapon == null) return;
        int weaponType = (int)_weapon.WeaponData.type;
        _rigConstraints.DisableAllRigs();
        _rigConstraints.EnableConstraint(_rigConstraints.Rigs[weaponType]);
    }
}