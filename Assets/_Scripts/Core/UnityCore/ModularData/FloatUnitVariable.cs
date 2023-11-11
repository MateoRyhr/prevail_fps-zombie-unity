using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "Variables/FloatUnitVariable", order = 0)]
public class FloatUnitVariable : ScriptableObject
{
    [Range(0f,1f)]
    public float Value;
}
