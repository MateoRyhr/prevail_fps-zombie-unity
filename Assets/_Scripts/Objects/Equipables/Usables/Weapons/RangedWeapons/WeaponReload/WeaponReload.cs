using UnityEngine;

public abstract class WeaponReload : MonoBehaviour
{
    public RangedWeapon Weapon;
    public int LastReloadAmount { get; protected set; }

    public abstract void Reload(int ammoAvailable,System.Action<int> SubstractAmmo);
}
