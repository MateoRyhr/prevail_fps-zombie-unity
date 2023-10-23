using System;
using UnityEngine;
using UnityEngine.Pool;

public class SingleShotLinearWeapon : RangedWeapon
{
    private ObjectPool<Projectile> _pool;

    private void Awake() =>
        _pool = new ObjectPool<Projectile>(CreateProjectile,OnTakeFromPool,ReturnToPool,DestroyFromPool,true,RangedWeaponData.magSize+1);
    
    private protected override void Update() => base.Update();

    protected override void Shoot()
    {
        Projectile projectile = _pool.Get();
    }

    Projectile CreateProjectile()
    {
        Projectile projectile =
            Instantiate
            (
                ProjectilePrefab,
                ProjectileStartPostition.position,
                Quaternion.LookRotation(GetBulletDirection(),Vector3.up)
            );
        projectile.Damage = WeaponData.damage;
        projectile.transform.parent = null;
        projectile.OnDestroyAfterImpact.AddListener(() => _pool.Release(projectile));
        return projectile;
    }

    void ReturnToPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        projectile.HasAlreadyCollided = false;
    }

    void OnTakeFromPool(Projectile projectile)
    {
        SetOnPosition(projectile.gameObject);
        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * RangedWeaponData.velocity;
        CurrentAmmo--;
        TimeSinceLastShoot = 0f;
        projectile.gameObject.SetActive(true);
    }

    void SetOnPosition(GameObject projectile)
    {
        projectile.transform.SetPositionAndRotation
        (
            ProjectileStartPostition.position,
            Quaternion.LookRotation(GetBulletDirection(),Vector3.up)
        );
    }

    void DestroyFromPool(Projectile projectile)
    {
        Destroy(projectile);
    }

    Vector3 GetBulletDirection() => Sight.GetRandomPointOnRadius() - ProjectileStartPostition.position;

    // public Component InstantiateObject()
    // {
    //     Projectile projectile =
    //         Instantiate
    //         (
    //             ProjectilePrefab,
    //             ProjectileStartPostition.position,
    //             Quaternion.LookRotation(GetBulletDirection(),Vector3.up)
    //         );
    //     projectile.Damage = WeaponData.damage;
    //     projectile.transform.parent = null;
    //     projectile.OnDestroyAfterImpact.AddListener(() => _pool.Release(projectile));
    //     return projectile;
    // }

    // public void OnGetComponent(Component projectile)
    // {
    //     SetOnPosition(projectile.gameObject);
    //     projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * RangedWeaponData.velocity;
    //     CurrentAmmo--;
    //     TimeSinceLastShoot = 0f;
    //     projectile.gameObject.SetActive(true);
    // }

    // public void OnReturnToPool(Component projectile)
    // {
    //     projectile.HasAlreadyCollided = false;
    //     projectile.gameObject.SetActive(false);
    // }

    // public void OnDestroyFromPool(Projectile component)
    // {
    //     throw new System.NotImplementedException();
    // }
}