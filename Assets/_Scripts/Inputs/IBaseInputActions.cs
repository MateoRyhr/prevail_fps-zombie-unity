using UnityEngine.InputSystem;

public interface IBaseInputActions
{
    public void OnInputStarted(InputAction.CallbackContext data);
    public void OnInputPerformed(InputAction.CallbackContext data);
    public void OnInputCanceled(InputAction.CallbackContext data);
}
