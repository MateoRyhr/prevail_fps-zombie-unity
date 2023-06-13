using UnityEngine;

public class GetterRigidbodyVelocityInOneAxis : MonoBehaviour, IFloat
{
    [SerializeField] Rigidbody _rigidBody;
    
    [Header("0 = x, 1 = y, 2 = z")]
    [SerializeField] int _axisIndex;
    public float Value { get => GetAxisVelocity(); set => Value = value; }
    
    private float GetAxisVelocity() {
        if(_axisIndex == 0)
            return _rigidBody.velocity.x;
        if(_axisIndex == 1)
            return _rigidBody.velocity.y;
        if(_axisIndex == 2)
            return _rigidBody.velocity.z;
        else
        {
            Debug.Log($"Axis wrong, must be 0, 1, or 2",this);
            return 0;
        }
    }
}
