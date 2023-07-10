using UnityEngine;

public class SingleShotLinearWeapon : RangedWeapon
{
    private void Update()
    {
        TimeSinceLastShoot += Time.deltaTime * Time.timeScale;
    }

    protected override void Shoot()
    {
        GameObject projectile = Instantiate(
            ProjectilePrefab,
            ProjectileStartPostition.position,
            Quaternion.LookRotation(ProjectileStartPostition.forward,Vector3.up)
        );
        projectile.GetComponent<IDamageDealer>().DamageAmount = WeaponData.damage;
        projectile.transform.parent = null;
        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * RangedWeaponData.velocity;
        // projectile.Velocity = projectile.transform.forward * RangedWeaponData.velocity;
        // projectile.Rotation = projectile.transform.rotation.eulerAngles;
        CurrentAmmo--;
        TimeSinceLastShoot = 0f;
    }

    // Vector3 GetBulletDirection() => EntityWeapon.Sight.GetRandomPointOnRadius() - ProjectileStartPostition.position;
}
