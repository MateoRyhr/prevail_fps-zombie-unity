using UnityEngine;
using TMPro;

public class ResolutionSetterUI : MonoBehaviour
{
    [SerializeField] private ScreenResolutionConfig _resolutionConfig;
    [SerializeField] private TextMeshProUGUI _text;

    private int _currentRes;

    private void Start() => SetSavedResolution();

    public void NextResolution()
    {
        if(_currentRes < Screen.resolutions.Length - 1)
            _currentRes++;
        else
            _currentRes = 0;
        SetText();
    }

    public void PreviousResolution()
    {
        if(_currentRes > 0)
            _currentRes--;
        else
            _currentRes = Screen.resolutions.Length - 1;
        SetText();
    }

    public void SetText()
    {
        int frameRate = (int)Screen.resolutions[_currentRes].refreshRateRatio.value;
        _text.text = $"{Screen.resolutions[_currentRes].width}x{Screen.resolutions[_currentRes].height}  {frameRate} Hz";
    }

    public void SetResolution()
    {
        _resolutionConfig.SetResolution(_currentRes);
    }

    public void SetSavedResolution()
    {
        _currentRes = _resolutionConfig.ResolutionSaved;
        SetText();
    }
}