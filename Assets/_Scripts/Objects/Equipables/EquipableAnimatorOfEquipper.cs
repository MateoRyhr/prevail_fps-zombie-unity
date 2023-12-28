using UnityEngine;

public class EquipableAnimatorOfEquipper : MonoBehaviour
{
    private Animator _animator;

    public void GetEntityAnimator()
    {
        _animator = GetComponentInParent<EquipperAnimator>().Animator;
    }

    public void PlayEquipperAnimation(string animation)
    {
        _animator.SetTrigger(animation);
    }

    public void ActiveBoolAnimation(string animation)
    {
        _animator.SetBool(animation,true);
    }

    public void DesactiveBoolAnimation(string animation)
    {
        _animator.SetBool(animation,false);
    }
}