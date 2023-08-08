using UnityEngine;

public abstract class Weapon : Usable
{
    public WeaponData WeaponData;
    [SerializeField] private bool _isRepeatedlyUsable;
    public override bool IsRepeatedlyUsable => _isRepeatedlyUsable;
}
