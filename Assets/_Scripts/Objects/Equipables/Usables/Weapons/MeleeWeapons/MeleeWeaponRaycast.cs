// using UnityEngine;
// using UnityEngine.Events;

// public class MeleeWeaponRaycast : MeleeWeapon
// {
//     [SerializeField] MeleeWeaponCollidable _collidable;
//     [SerializeField] ForceApplier _forceApplier;

//     public UnityEvent OnImpact;

//     public override void HitStart()
//     {

//     }

//     public override void HitEnd()
//     {
//         if(!Physics.Raycast(EntityWeapon.Sight.Camera.transform.position,EntityWeapon.Sight.Camera.transform.forward,out RaycastHit hit,MeleeWeaponData.attackRange,ImpactableLayers))
//             return;
//         MeleeWeaponCollidable collidable = Instantiate(_collidable,hit.point,_collidable.transform.rotation);
//         collidable.Damage = WeaponData.damage;
//     }
// }
