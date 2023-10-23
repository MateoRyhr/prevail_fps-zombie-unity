using UnityEngine;
using UnityEngine.Events;

public class EntityGroundState : MonoBehaviour
{
    [Tooltip("The layer assigned to the ground - Needed to check if is on the ground")]
    [SerializeField] public LayerMask GroundLayer;
    public bool IsBeingAffectedByAnExternalForce { get; set; }
    public bool IsMoving { get; set; }
    public bool IsMovingOnGround { get; set; }
    public bool IsOnGround { get; set; }
    [SerializeField] private CapsuleCollider _collider;
    private Rigidbody _rb;

    private float _groundCheckRadiusModifier = 0.5f;

    public UnityEvent OnLeftGround;
    public UnityEvent OnLand;

    private bool _groundDetected;

    private void Awake()
    {
        _collider = GetComponent<CapsuleCollider>();
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _groundDetected = DetectGround();
        if(IsOnGround != _groundDetected)
            if(_groundDetected)
            {
                OnLand?.Invoke();
            }
            else
            {
                OnLeftGround?.Invoke();
                IsMovingOnGround = false;
            }
        IsOnGround = _groundDetected;
    }

    public bool DetectGround() => Physics.CheckSphere(transform.position,_collider.radius * _groundCheckRadiusModifier,GroundLayer);

    public bool CanMove() => !IsBeingAffectedByAnExternalForce;

    public void ApplyForce()
    {
        IsBeingAffectedByAnExternalForce = true;
        this.InvokeScaledDeltaTime(() => IsBeingAffectedByAnExternalForce = false,0.5f);
    }
}
