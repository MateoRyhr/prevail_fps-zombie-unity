using UnityEngine;
using UnityEngine.Events;

public class ActionAfterHoldingATime : MonoBehaviour
{
    [SerializeField] private HoldableButtonInput _button;
    [SerializeField] private float _timeHoldingToPerformAction;
    [SerializeField] private bool _repeatAction;

    public UnityEvent OnActionPerformed;
    public UnityEvent OnReleaseButton;

    private void Awake()
    {
        _button.OnReleased.AddListener(ReleaseButton);
    }

    public void StartHoldButton()
    {
        this.Invoke(() => {
            OnActionPerformed?.Invoke();
            if(_repeatAction)
                _button.OnStarted?.Invoke();
        },_timeHoldingToPerformAction);
    }

    public void ReleaseButton()
    {
        StopAllCoroutines();
        OnReleaseButton?.Invoke();
    }
}
