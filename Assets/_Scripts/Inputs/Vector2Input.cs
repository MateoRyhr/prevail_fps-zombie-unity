using UnityEngine;

public class Vector2Input : BasicInput, IVector2
{
    public Vector2 Value { get => GetValue(); set => Value = value;}
    private Vector2 GetValue() => _actionAsset.actionMaps[_actionMapNumber].actions[_actionNumber].ReadValue<Vector2>(); 
}
