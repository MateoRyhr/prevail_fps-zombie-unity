using UnityEngine;

public class AcelerationMover : IMover
{
    public IMovement Movement { get => AceleratedMovement; }
    public IAceleratedMovement AceleratedMovement { get; private set; }

    private AnimationCurve _acelerationCurve;
    private AnimationCurve _decelerationCurve;

    private float _timeSpeedingUp;
    private float _timeSlowingDown;

    private Vector3 _lastMovementDirection;
    private float _lastSpeed;

    public AcelerationMover(IAceleratedMovement movement,AnimationCurve acelerationCurve, AnimationCurve decelerationCurve)
    {
        AceleratedMovement = movement;
        _acelerationCurve = acelerationCurve;
        _decelerationCurve = decelerationCurve;
        _lastMovementDirection = Vector3.zero;
    }

    public Vector3 Move(Vector3 direction, float timeLapsed)
    {
        bool isMoving = direction != Vector3.zero;

        // float speedCostForNewDirection = 1 - Vector3.Angle(_lastMovementDirection,direction) / 180f;
        // _timeSpeedingUp = AceleratedMovement.TimeToReachMaxSpeed * (_lastSpeed * speedCostForNewDirection / AceleratedMovement.MaxSpeed);
        _timeSpeedingUp = AceleratedMovement.TimeToReachMaxSpeed * (_lastSpeed / AceleratedMovement.MaxSpeed);
        _timeSlowingDown = AceleratedMovement.TimeToStop * (_lastSpeed / AceleratedMovement.MaxSpeed);

        if(isMoving)
            return Acelerate(direction,timeLapsed);
        else
            return Decelerate(timeLapsed);
    }

    Vector3 Acelerate(Vector3 direction, float timeLapsed)
    {
        _timeSpeedingUp += timeLapsed;
        _lastMovementDirection = direction;
        _lastSpeed = GetSpeedInCurve(_acelerationCurve,_timeSpeedingUp,AceleratedMovement.TimeToReachMaxSpeed);
        return direction * _lastSpeed;
    }

    Vector3 Decelerate(float timeLapsed)
    {
        _timeSlowingDown -= timeLapsed;
        _lastSpeed = GetSpeedInCurve(_decelerationCurve,_timeSlowingDown,AceleratedMovement.TimeToStop);;
        return _lastMovementDirection * _lastSpeed;
    }

    float GetSpeedInCurve(AnimationCurve curve,float currentTime, float timeToReach) => curve.Evaluate(currentTime/timeToReach) * AceleratedMovement.MaxSpeed;
}