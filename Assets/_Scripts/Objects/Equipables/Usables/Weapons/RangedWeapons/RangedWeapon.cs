using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class RangedWeapon : Weapon
{
    public RangedWeaponData RangedWeaponData;
    public WeaponReload WeaponReload;
    public Projectile ProjectilePrefab;
    public Transform ProjectileStartPostition;
    public int CurrentAmmo { get; set; }
    
    [HideInInspector] public RadiusSight Sight;

    public bool IsReloading { get; set; }
    public bool WaitingForFireRate { get; set; }
    public float TimeSinceLastShoot { get; set; }

    public UnityEvent OnWeaponEmpty;

    private protected virtual void Update() => TimeSinceLastShoot += Time.deltaTime * Time.timeScale;

    public override void Use()
    {
        if(CurrentAmmo == 0)
        {
            OnWeaponEmpty?.Invoke();
            return;
        }
        if(!CanShoot()) return;
        Shoot();
        Recoil();
        OnUse?.Invoke();
    }

    private void Recoil()
    {
        Sight.TimeRecovering = 0f;
        Sight.TimeWaitingToStartRecovery = 0f;
        Sight.SightRadius += RangedWeaponData.recoilForce;
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
    public bool FireRateEnabled() => TimeSinceLastShoot > TimeTillANextRound();
    public float TimeTillANextRound() => 1f / (RangedWeaponData.fireRate / 60f);

    public void SetSight()
    {
        Sight = GetComponentInParent<RadiusSight>();
    }
}