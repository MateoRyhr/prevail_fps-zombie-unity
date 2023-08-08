using UnityEngine;

public class AmmoInitializer : MonoBehaviour
{
    [SerializeField] RangedWeapon _weapon;
    [SerializeField] private int _initialAmmo;

    private void Awake() => _weapon.CurrentAmmo = _initialAmmo;
}
