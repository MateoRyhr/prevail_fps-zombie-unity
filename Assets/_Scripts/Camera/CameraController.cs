public class CameraController
{
    /// <summary>Returns current + input * sensivity</summary>
    public float GetRotation(float current, float input, float sensivity) => current + input * sensivity;
}