using UnityEngine;

public class EntityPhysicMovementAnimation3D : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private FloatVariable _maxSpeed;
    [SerializeField] private FloatVariable _animationSmoother;
    [SerializeField] private Rigidbody _rigidBody;

    const string VEL_X = "vel-x";
    const string VEL_Z = "vel-z";

    Vector3 _lastVelocity;

    private void Update()
    {
        UpdateVelocity();
    }

    void UpdateVelocity()
    {
        _lastVelocity = new Vector3(_animator.GetFloat(VEL_X),0f,_animator.GetFloat(VEL_Z));
        
        Vector3 localVelocity = _rigidBody.transform.InverseTransformDirection(_rigidBody.velocity) / _maxSpeed.Value;
        Vector3 smoothedVelocity = Vector3.Lerp(_lastVelocity,localVelocity,_animationSmoother.Value);
        
        _animator.SetFloat(VEL_X,smoothedVelocity.x);
        _animator.SetFloat(VEL_Z,smoothedVelocity.z);
    }
}
