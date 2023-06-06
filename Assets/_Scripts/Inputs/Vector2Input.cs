using UnityEngine;

public class Vector2Input : BasicInput
{
    public Vector2 InputValue => GetValue();
    private Vector2 GetValue() => _actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].ReadValue<Vector2>(); 
}
