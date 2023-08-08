using UnityEngine;

[CreateAssetMenu(fileName = "RangedWeaponData", menuName = "Weapon/RangedWeaponData")]
public class RangedWeaponData : ScriptableObject
{
    [Header("Shooting")]
    public float maxDistance;
    public float velocity;
    public float recoilForce;
    [Tooltip("In rounds per minute")]
    public float fireRate;                      //In Rounds per minute
    // public float recoilRecoveryTime;
    [Header("Reloading")] 
    public AmmoType ammoType;
    public int magSize;
    public bool hasBulletChamber;
    // public GameObject reloadPrefab;
    [Header("Firemode")]
    public bool isAutomatic;
}
