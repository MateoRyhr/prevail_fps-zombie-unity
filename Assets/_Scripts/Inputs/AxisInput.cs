public class AxisInput : BasicInput
{
    public float AxisValue => GetValue();
    private float GetValue() => _actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].ReadValue<float>(); 
}