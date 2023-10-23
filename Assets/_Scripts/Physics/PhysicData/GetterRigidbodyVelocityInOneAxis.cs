using UnityEngine;

public class GetterRigidbodyVelocityInOneAxis : MonoBehaviour, IFloat
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private bool _useLocalVelocity;
    [Header("0 = x, 1 = y, 2 = z")]
    [SerializeField] int _axisIndex;
    public float Value { get => GetAxisVelocity(); set => Value = value; }

    private Vector3 _velocity;
    private void Awake() => _velocity = new Vector3(0f,0f,0f);

    private float GetAxisVelocity() {
        _velocity = _useLocalVelocity
            ? _rigidBody.transform.InverseTransformDirection(_rigidBody.velocity)
            : _rigidBody.velocity;
        if(_axisIndex == 0)
            return _velocity.x;
        if(_axisIndex == 1)
            return _velocity.y;
        if(_axisIndex == 2)
            return _velocity.z;
        else
        {
            Debug.Log($"Axis wrong, must be 0, 1, or 2",this);
            return 0;
        }
    }
}