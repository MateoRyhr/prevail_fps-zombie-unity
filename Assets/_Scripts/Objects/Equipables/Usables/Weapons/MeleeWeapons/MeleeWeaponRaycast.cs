using UnityEngine;
using UnityEngine.Events;

public class MeleeWeaponRaycast : MeleeWeapon
{
    [SerializeField] MeleeWeaponCollidable _collidable;
    [SerializeField] Transform _sightContainer;
    
    private Sight _sight;
    public Sight Sight { get => _sight; }

    public UnityEvent OnImpact;

    private void Start() => _sight = _sightContainer.GetComponentInChildren<Sight>();

    public override void HitStart()
    {

    }

    public override void HitEnd()
    {
        if(!Physics.Raycast(Sight.Camera.transform.position,Sight.Camera.transform.forward,out RaycastHit hit,MeleeWeaponData.attackRange,ImpactableLayers))
            return;
        MeleeWeaponCollidable collidable = Instantiate(_collidable,hit.point,_collidable.transform.rotation);
        collidable.Damage = WeaponData.damage;
    }
}
