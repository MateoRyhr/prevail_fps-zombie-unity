using UnityEngine;

public class TriggerOfMeleeWeapon : MonoBehaviour
{
    // [SerializeField] private int[] _enemiesLayers;
    [SerializeField] private Transform _collidableParent;
    [SerializeField] private MeleeWeaponCollidable _collidable;
    [SerializeField] private MeleeWeaponByCollision _meleeWeapon;
    public MeleeWeaponCollidable Collidable => _collidable;

    private void OnTriggerEnter(Collider other)
    {
        if(!LayerUtil.LayerContains(_meleeWeapon.ImpactableLayers,other.gameObject.layer)) return;
        // if(!IsEnemy(other.gameObject)) return;
        MeleeWeaponCollidable collidable = Instantiate(_collidable,_collidableParent);
        collidable.Damage = _meleeWeapon.WeaponData.damage;
        gameObject.SetActive(false);
        // Debug.Log("Trigger detects enemy");
    }

    // public bool IsEnemy(GameObject other)
    // {
    //     foreach (int enemyLayer in _enemiesLayers)
    //     {
    //         if(other.layer == enemyLayer) return true;
    //     }
    //     return false;
    // }
}
