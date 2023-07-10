using UnityEngine;

[CreateAssetMenu (fileName = "Weapon",menuName = "Weapon/Weapon")]
public class WeaponData : ScriptableObject
{
    public int weaponId;
    public WeaponType type;
    public float damage;
}
