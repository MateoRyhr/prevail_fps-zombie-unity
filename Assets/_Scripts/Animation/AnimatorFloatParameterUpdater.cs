using UnityEngine;

public class AnimatorFloatParameterUpdater : MonoBehaviour
{
    [SerializeField] private string _parameterName;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _dataContainer;
    [SerializeField] private FloatVariable _animationSmooth;
    [Tooltip("The value will be divided by this")][SerializeField] FloatVariable _valueModifier;

    private IFloat _value;
    private void Awake() => _value = _dataContainer.GetComponent<IFloat>();

    private void Update() =>_animator.SetFloat
    (
        _parameterName,
        Lerper.LerpFloat
        (
            _animator.GetFloat(_parameterName),
            _valueModifier != null ? _value.Value /_valueModifier.Value : _value.Value,
            _animationSmooth.Value
        )
    );
}
