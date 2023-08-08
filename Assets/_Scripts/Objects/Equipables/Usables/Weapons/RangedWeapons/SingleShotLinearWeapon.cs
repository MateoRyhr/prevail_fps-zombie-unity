using UnityEngine;

public class SingleShotLinearWeapon : RangedWeapon
{
    private protected override void Update() => base.Update();

    protected override void Shoot()
    {
        GameObject projectile = Instantiate(
            ProjectilePrefab,
            ProjectileStartPostition.position,
            Quaternion.LookRotation(GetBulletDirection(),Vector3.up)
        );
        projectile.GetComponent<Projectile>().Damage = WeaponData.damage;
        projectile.transform.parent = null;
        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * RangedWeaponData.velocity;
        CurrentAmmo--;
        TimeSinceLastShoot = 0f;
    }

    Vector3 GetBulletDirection() => Sight.GetRandomPointOnRadius() - ProjectileStartPostition.position;
}
