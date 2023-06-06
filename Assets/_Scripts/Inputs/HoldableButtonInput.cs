using UnityEngine.Events;

public class HoldableButtonInput : BasicInput
{
    public UnityEvent OnIsPressed;
    public UnityEvent OnReleased;

    private bool _pressed;

    private void Update() => HandlePressed();

    void HandlePressed()
    {
        if(_actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].IsPressed())
        {
            OnIsPressed?.Invoke();
            _pressed = true;
        }
        else
        {
            if(_pressed)
                OnReleased?.Invoke();
            _pressed = false;
        }
    }
}
