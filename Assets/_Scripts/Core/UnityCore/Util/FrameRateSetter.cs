using UnityEngine;

public class FrameRateSetter : MonoBehaviour
{
    [SerializeField] IntVariable TargetFrameRate;

    private void Awake() {
        Application.targetFrameRate = TargetFrameRate.Value;
    }
}
