using UnityEngine;
using UnityEngine.Animations.Rigging;

public class SimpleRigAnimation : MonoBehaviour
{
    [SerializeField] private Rig _rig;
    [SerializeField] private float _animationTime;
    [SerializeField] private AnimationCurve _animationCurve;

    public void PlayAnimationRig() =>
        Lerper.LerpFloatFollowingCurve(this,_animationTime,_animationCurve,SetRigWeight,false);

    void SetRigWeight(float weight) => _rig.weight = weight;
}
