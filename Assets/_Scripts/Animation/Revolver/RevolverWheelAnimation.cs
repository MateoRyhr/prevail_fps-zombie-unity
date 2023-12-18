using UnityEngine;

public class RevolverWheelAnimation : MonoBehaviour
{
    [SerializeField] private Transform _wheel;
    [SerializeField] private int _bullets;
    [SerializeField] private Vector3 _rotationAxis;

    public void RotateWheel()
    {
        Vector3 rotation = _rotationAxis * 360f / _bullets;
        _wheel.Rotate(rotation);
    }
}
