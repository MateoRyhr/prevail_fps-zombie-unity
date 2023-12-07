using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class HDRPLightUpdateShadowMode : MonoBehaviour
{
    [SerializeField] private HDAdditionalLightData _light;

    public void UpdateLightShadowMode(int updateMode)
    {
        _light.SetShadowUpdateMode((ShadowUpdateMode)updateMode);
        _light.UpdateAllLightValues();
    }
}
