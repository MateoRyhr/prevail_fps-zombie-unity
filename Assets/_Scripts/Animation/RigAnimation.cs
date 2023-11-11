using UnityEngine;
using UnityEngine.Animations.Rigging;

public class RigAnimation : MonoBehaviour
{
    [SerializeField] private Rig _rig;
    [Tooltip("Needs to implement IFloat")]
    [SerializeField] private GameObject _animationTimeContainer;
    [SerializeField] private AnimationCurve _animationInCurve;
    [SerializeField] private float _timeRatioEnterAnimation;
    [SerializeField] private AnimationCurve _animationOutCurve;
    [SerializeField] private float _timeRatioExitAnimation;

    IFloat _animationTimeGetter;

    private void Awake() => _animationTimeGetter = _animationTimeContainer.GetComponent<IFloat>();

    public void PlayRigAnimation()
    {
        float animationTime = _animationTimeGetter.Value;
        Debug.Log($"Animation time: {animationTime}");
        ActiveRig(animationTime * _timeRatioEnterAnimation);
        this.InvokeScaledDeltaTime(
            () => DesactiveRig(animationTime * _timeRatioEnterAnimation),
            animationTime * (1 - _timeRatioEnterAnimation - _timeRatioExitAnimation)
        );
    }

    void ActiveRig(float time)
    {
        Lerper.LerpFloat(this,0,1,time,SetRigWeight,false,_animationInCurve);
    }

    void DesactiveRig(float time)
    {
        Lerper.LerpFloat(this,1,0,time,SetRigWeight,false,_animationOutCurve);
    }

    void SetRigWeight(float weight) => _rig.weight = weight;
}
