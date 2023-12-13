using UnityEngine;

public class ScreenResolutionConfig : MonoBehaviour
{
    public int ResolutionSaved { get; set; }
    public Resolution Resolution { get => Screen.resolutions[ResolutionSaved]; }
    
    const string RESOLUTION = "resolution";

    private void Awake() {
        ResolutionSaved = PlayerPrefs.GetInt(RESOLUTION,0);
        SetResolution(ResolutionSaved);
        SaveResolution();
    }

    public void SetResolution(int resIndex)
    {
        ResolutionSaved = resIndex;
        Screen.SetResolution(Resolution.width,Resolution.height,FullScreenMode.ExclusiveFullScreen,Resolution.refreshRateRatio);
        SaveResolution();
    }

    void SaveResolution()
    {
        PlayerPrefs.SetInt(RESOLUTION,ResolutionSaved);
        PlayerPrefs.Save();
    }
}
