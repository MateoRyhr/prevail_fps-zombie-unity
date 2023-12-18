using System;
using UnityEngine;
using UnityEngine.Events;

public class MagReload : WeaponReload, IInt
{
    [SerializeField] float _reloadTime;
    [SerializeField] float _noEmptyMagReloadTime;

    public UnityEvent OnReloadStarts;
    public UnityEvent OnNoEmptyMagReloadStarts;
    public UnityEvent OnReloadEnd;

    public int Value { get => LastReloadAmount; set => throw new NotImplementedException(); }

    public override void Reload(int ammoAvailable, Action<int> SubstractAmmo)
    {
        int ammoToReload = Weapon.RangedWeaponData.magSize - Weapon.CurrentAmmo;
        if(Weapon.RangedWeaponData.hasBulletChamber && Weapon.CurrentAmmo > 0) ammoToReload++;
        if(ammoAvailable < ammoToReload) ammoToReload = ammoAvailable;
        LastReloadAmount = ammoToReload;
        float reloadTime;
        Weapon.IsReloading = true;
        if(Weapon.CurrentAmmo > 0)
        {
            reloadTime = _noEmptyMagReloadTime;
            OnNoEmptyMagReloadStarts?.Invoke();
        }
        else
        {
            reloadTime = _reloadTime;
            OnReloadStarts?.Invoke();
        }
        this.InvokeScaledDeltaTime(() => {
            Weapon.CurrentAmmo += ammoToReload;
            SubstractAmmo(ammoToReload);
            Weapon.IsReloading = false;
            OnReloadEnd?.Invoke();
        },reloadTime);
    }
}
