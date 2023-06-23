using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(InputEnabler))]
public class BasicInput : MonoBehaviour, IBaseInputActions
{
    [SerializeField] protected InputActionAsset _actionAsset;
    [SerializeField] protected int _actionMapNumber;
    [SerializeField] protected int _actionNumber;

    [Header("Debugging")]
    [SerializeField] private Logger _logger;

    public UnityEvent OnStarted;
    public UnityEvent OnCanceled;
    public UnityEvent OnPerformed;

    public void OnInputStarted(InputAction.CallbackContext data)
    {
        OnStarted?.Invoke();
        _logger.Log(data,this);
    }
    public void OnInputPerformed(InputAction.CallbackContext data)
    {
        OnPerformed?.Invoke();
        _logger.Log(data,this);
    }
    public void OnInputCanceled(InputAction.CallbackContext data)
    {
        OnCanceled?.Invoke();
        _logger.Log(data,this);
    }

    public void SuscribeInputs()
    {
        _actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].started += OnInputStarted;
        _actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].performed += OnInputPerformed;
        _actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].canceled += OnInputCanceled;
    }

    public void UnsubscribeInputs()
    {
        _actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].started -= OnInputStarted;
        _actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].performed -= OnInputPerformed;
        _actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].canceled -= OnInputCanceled;
    }
}
