using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class RangedWeapon : Weapon
{
    public RangedWeaponData RangedWeaponData;
    public WeaponReload WeaponReload;
    public GameObject ProjectilePrefab;
    public Transform ProjectileStartPostition;
    public int CurrentAmmo { get; set; }

    public bool IsReloading { get; set; }
    public bool WaitingForFireRate { get; set; }
    public float TimeSinceLastShoot { get; set; }

    public UnityEvent OnWeaponEmpty;

    public override void Use()
    {
        if(!CanShoot()) return;
        Shoot();
        if(CurrentAmmo == 0)
            OnWeaponEmpty?.Invoke();
        Recoil();
        OnUse?.Invoke();
    }

    private void Recoil()
    {
        
    }

    public bool CanReload()
    {
        if(IsReloading) return false;
        if(RangedWeaponData.hasBulletChamber) return CurrentAmmo <= RangedWeaponData.magSize;
        else return CurrentAmmo < RangedWeaponData.magSize;
    }

    protected abstract void Shoot();

    public void Reload(int ammoAvailable, Action<int> SubstractAmmo)
    {
        if(CanReload()) WeaponReload.Reload(ammoAvailable,SubstractAmmo);
    }

    public bool CanShoot() => CurrentAmmo > 0 && !IsReloading && FireRateEnabled();
    public bool FireRateEnabled() => TimeSinceLastShoot >= TimeTillANextRound();
    public float TimeTillANextRound() => 1f / (RangedWeaponData.fireRate / 60f);
}
