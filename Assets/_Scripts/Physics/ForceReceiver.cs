using UnityEngine;

// [RequireComponent(typeof(Rigidbody))]
public class ForceReceiver : MonoBehaviour
{
    [SerializeField] FloatVariable _forceMultiplier;
    [SerializeField] private Rigidbody _rigidbody;
    public Vector3 ForceReceived { get; set; }
    // private float _timeUntilClearForce;

    private float _forceMultiplierValue;

    private void Awake()
    {
        if(!_rigidbody)
            _rigidbody = GetComponent<Rigidbody>();
        _forceMultiplierValue = 1f;
        if(_forceMultiplier) _forceMultiplierValue = _forceMultiplier.Value;
        // _timeUntilClearForce = Time.fixedTime * 2;
    }

    public void ReceiveForceAtPoint(Vector3 force,Vector3 contactPoint)
    {
        ReceiveForceAtPoint(force,contactPoint,0f);
    }

    public void ReceiveForceAtPoint(Vector3 force,Vector3 contactPoint, float delay)
    {
        force *= _forceMultiplierValue;
        ForceReceived += force;
        // this.Invoke(() => ForceReceived -= force,_timeUntilClearForce);
        this.InvokeScaledDeltaTime(() => {
            if(_rigidbody)
            {
                _rigidbody.AddForceAtPosition(force,contactPoint,ForceMode.Impulse);
            }
            else
            {
                Debug.Log($"Force Receiver doesn't have RigidBody");
            }
        },delay);
    }

    public void ReceiveForce(Vector3 force)
    {
        ReceiveForce(force,0f);
    }

    public void ReceiveForce(Vector3 force, float delay)
    {
        force *= _forceMultiplierValue;
        ForceReceived += force;
        // this.Invoke(() => ForceReceived -= force,_timeUntilClearForce);
        this.InvokeScaledDeltaTime(() => {
            if(_rigidbody)
            {
                _rigidbody.AddForce(force,ForceMode.Impulse);
            }
            else
            {
                Debug.Log($"Force Receiver doesn't have RigidBody");
            }
        },delay);
    }

    public void SetRigidbody(Rigidbody rb)
    {
        _rigidbody = rb;
    }
}
