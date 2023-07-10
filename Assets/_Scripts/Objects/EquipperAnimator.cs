using UnityEngine;

public class EquipperAnimator : MonoBehaviour
{
    [SerializeField] private Transform _parentOnEquipping;
    [SerializeField] private Animator _equipperAnimator;
    public Animator Animator => _equipperAnimator;

    public void PlayEquipAnimation()
    {
        string animationName = _parentOnEquipping.GetComponentInChildren<EquipableAnimations>().EquippingAnimation;
        _equipperAnimator.SetTrigger(animationName);
    }

    public void PlayUnequipAnimation()
    {
        string animationName = _parentOnEquipping.GetComponentInChildren<EquipableAnimations>().UnequippingAnimation;
        _equipperAnimator.SetTrigger(animationName);
    }
}