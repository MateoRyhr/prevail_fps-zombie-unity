using UnityEngine;

public class TransformRotationTransporter : MonoBehaviour
{
    [SerializeField] private Transform _source;
    [SerializeField] private Transform _receiver;
    [SerializeField] private bool _useAxisX;
    [SerializeField] private bool _useAxisY;
    [SerializeField] private bool _useAxisZ;

    private Vector3 _newRotation;

    private void Awake() => _newRotation = new Vector3(0,0,0);
    private void Update()
    {
        if(_useAxisX)
            _newRotation.x = _source.localRotation.eulerAngles.x;
        else
            _newRotation.x = _receiver.localRotation.eulerAngles.x;

        if(_useAxisY)
            _newRotation.y = _source.localRotation.eulerAngles.y;
        else
            _newRotation.y = _receiver.localRotation.eulerAngles.y;

        if(_useAxisZ)
            _newRotation.z = _source.localRotation.eulerAngles.z;
        else
            _newRotation.z = _receiver.localRotation.eulerAngles.z;

        _receiver.localRotation = Quaternion.Euler(_newRotation);
    }
}
