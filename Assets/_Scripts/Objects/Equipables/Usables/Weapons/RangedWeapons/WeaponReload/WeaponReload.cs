using UnityEngine;

public abstract class WeaponReload : MonoBehaviour
{
    public RangedWeapon Weapon;

    public abstract void Reload(int ammoAvailable,System.Action<int> SubstractAmmo);
}
