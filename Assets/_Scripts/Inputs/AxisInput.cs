public class AxisInput : BasicInput, IFloat
{
    public float Value { get => GetValue(); set => Value = value; }
    private float GetValue() => _actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].ReadValue<float>(); 
}