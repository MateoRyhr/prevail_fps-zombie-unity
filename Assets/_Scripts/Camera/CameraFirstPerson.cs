using UnityEngine;

public class CameraFirstPerson : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private FloatVariable _maxRotationInX;
    [SerializeField] private FloatVariable _sensivity;
    [SerializeField] private FloatVariable _sensivityX;
    [SerializeField] private FloatVariable _sensivityY;
    [SerializeField] private BoolVariable _yAxisInputInverted;
    [Header("Vector2 - Delta Input")]
    [SerializeField] private GameObject _vector2InputContainer;
    [Header("Rotation data containers")]
    [SerializeField] private Transform _cameraRotationInX;
    [SerializeField] private Transform _cameraRotationInY;

    private CameraController _cameraController;
    private IVector2 _inputVector2;
    private Vector2 _input => _inputVector2.Value;
    private Vector2 _lookRotation;
    float _yInputDirection = 1f;

    private void Awake()
    {
        _cameraController = new CameraController();
        _inputVector2 = _vector2InputContainer.GetComponent<IVector2>();
        if(_yAxisInputInverted) _yInputDirection = -1f;
    }

    private void Update() => UpdateCamera();

    void UpdateCamera()
    {
        _lookRotation.x = _cameraController.GetRotation(_lookRotation.x ,_input.y * _yInputDirection, _sensivity.Value * _sensivityY.Value);
        _lookRotation.y = _cameraController.GetRotation(_lookRotation.y ,_input.x, _sensivity.Value * _sensivityX.Value);

        _lookRotation.x = Mathf.Clamp(_lookRotation.x,-_maxRotationInX.Value,_maxRotationInX.Value);

        _cameraRotationInX.localRotation = Quaternion.Euler(_lookRotation.x,0f,0f);
        _cameraRotationInY.localRotation = Quaternion.Euler(0f,_lookRotation.y,0f);
    }
}
