using UnityEngine;

public class ScreenResolutionSetter : MonoBehaviour
{
    [Tooltip("A gameobject that implements IVector2 interface as a screen resolution")]
    [SerializeField] private GameObject _resolutionContainer;
    IVector2 _resolution;

    public void SetResolution()
    {
        // Screen.SetResolution()
    }
}