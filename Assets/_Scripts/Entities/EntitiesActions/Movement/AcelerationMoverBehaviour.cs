using UnityEngine;
using UnityEngine.Events;

public class AcelerationMoverBehaviour : MoverBehaviour, IAceleratedMovement
{
    [Header("Required")]
    [SerializeField] private Rigidbody _rigidBody;
    [Header("Settings")]
    [Header("The curve need to go from 0 to 1")] [SerializeField] private AnimationCurve _acelerationCurve;
    [Header("The curve need to go from 0 to 1")] [SerializeField] private AnimationCurve _decelerationCurve;
    [SerializeField] private FloatVariable _timeToReachMaxSpeed;
    [SerializeField] private FloatVariable _timeToStop;
    
    public float TimeToReachMaxSpeed => _timeToReachMaxSpeed.Value;
    public float TimeToStop => _timeToStop.Value;
    public float MaxSpeed => _maxSpeed.Value;

    public UnityEvent OnStartMove;
    public UnityEvent OnNoMove;

    [Space] [Header("Debugging")]
    [SerializeField] private Logger _logger;

    private bool _isMoving;

    private protected override void Awake()
    {
        base.Awake();
        _mover = new AcelerationMover(this,_acelerationCurve,_decelerationCurve);
    }

    private void FixedUpdate()
    {
        if(!_isMoving)
        {
            if(_direction.Value != Vector2.zero)
            {
                _isMoving = true;
                OnStartMove?.Invoke();
            }
        }
        else
        {
            if(_direction.Value == Vector2.zero)
            {
                _isMoving = false;
                OnNoMove?.Invoke();
            }
        }
        ApplyMovement(_mover.Move(GetMovementDirection(),Time.fixedDeltaTime));
    }

    void ApplyMovement(Vector3 velocity) => _rigidBody.velocity = new Vector3(velocity.x,_rigidBody.velocity.y,velocity.z);
    Vector3 GetMovementDirection() => transform.TransformDirection(new Vector3(_direction.Value.x,0f,_direction.Value.y));
}