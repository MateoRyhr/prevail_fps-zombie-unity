using UnityEngine;

public class MeleeWeaponByCollision : MeleeWeapon
{
    [SerializeField] private Collider _weaponTrigger;

    public override void HitStart()
    {
        _weaponTrigger.gameObject.SetActive(true);
    }

    public override void HitEnd()
    {
        _weaponTrigger.gameObject.SetActive(false);
    }
}
