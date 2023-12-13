using UnityEngine;
using UnityEngine.Events;

public class AIEnemyDetector : MonoBehaviour, ICollider
{
    public Collider EnemyInSight { get; private set; }
    public Collider Collider => EnemyInSight;

    [SerializeField] private Collider _entityCollider;
    [SerializeField] private Transform _visionOriginPoint;
    [Tooltip("The amplitude of the field of view in degrees")]
    [SerializeField] private FloatVariable _horizontalFieldOfView;
    [SerializeField] private FloatVariable _verticalFieldOfView;
    [Tooltip("How far can see")]
    [SerializeField] private FloatVariable _visionRange;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private LayerMask _obstructionLayer;

    public UnityEvent OnEnemyDetected;
    public UnityEvent OnEnemyLost;

    private bool _wasEnemyInSight;

    private Collider[] _rangeChecks;

    private void FixedUpdate()
    {
        See();
        if(!_wasEnemyInSight && EnemyInSight != null)
            OnEnemyDetected?.Invoke();
        if(_wasEnemyInSight && EnemyInSight == null)
            OnEnemyLost?.Invoke();
        _wasEnemyInSight = EnemyInSight != null;
    }

    private void See()
    {
        EnemyInSight = null;
        _rangeChecks = Physics.OverlapSphere(_visionOriginPoint.position,_visionRange.Value,_enemyLayer);
        if(_rangeChecks.Length == 0) return;
        // Vector3 targetPointInSight = _rangeChecks[0].ClosestPoint(_visionOriginPoint.position);
        Vector3 targetPosition = _rangeChecks[0].bounds.center;
        Vector3 directionToTarget = (targetPosition - _visionOriginPoint.position).normalized;
        Vector3 forward = _visionOriginPoint.forward;

        float angleDifferenceX = Vector2.Angle(new Vector2(forward.x,forward.z),new Vector2(directionToTarget.x,directionToTarget.z));
        float angleDifferenceY = Vector3.Angle(forward,directionToTarget);

        //If the enemy is inside the field of view <)
        if
        (   
            angleDifferenceX < _horizontalFieldOfView.Value / 2 &&
            angleDifferenceY < _verticalFieldOfView.Value / 2
        )
        { 
            float distanceToTarget = Vector2.Distance(_visionOriginPoint.position, targetPosition);
            //If the enemy is not being obstucted.
            bool isSightObstructedFromView = Physics.Raycast(_visionOriginPoint.position,directionToTarget,distanceToTarget,_obstructionLayer);
            bool isSightObstructedFromEnemy = Physics.Raycast(targetPosition,directionToTarget*-1,distanceToTarget,_obstructionLayer);
            if(!isSightObstructedFromView && !isSightObstructedFromEnemy)
            {
                EnemyInSight = _rangeChecks[0];
            }
        }
    }

    //Uncomment for debugging

    // private void OnDrawGizmos()
    // {

    //     // Draw vision range
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireSphere(_visionOriginPoint.position, _visionRange.Value);
    //     //Draw forward
    //     Gizmos.DrawLine(_visionOriginPoint.position,_visionOriginPoint.position + _visionOriginPoint.forward * _visionRange.Value);

    //     // Draw horizontal field of view limits
    //     Gizmos.color = Color.red;
    //     float halfFOV = _horizontalFieldOfView.Value / 2f;
    //     Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, Vector3.up);
    //     Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, Vector3.up);
    //     Vector3 leftRayDirection = leftRayRotation * _visionOriginPoint.forward;
    //     Vector3 rightRayDirection = rightRayRotation * _visionOriginPoint.forward;
    //     Gizmos.DrawLine(_visionOriginPoint.position, _visionOriginPoint.position + leftRayDirection * _visionRange.Value);
    //     Gizmos.DrawLine(_visionOriginPoint.position, _visionOriginPoint.position + rightRayDirection * _visionRange.Value);

    //     // Draw vertical field of view limits
    //     Gizmos.color = Color.green;
    //     halfFOV = _verticalFieldOfView.Value / 2f;
    //     Quaternion upRayRotation = Quaternion.AngleAxis(-halfFOV, _visionOriginPoint.right);
    //     Quaternion downRayRotation = Quaternion.AngleAxis(halfFOV, _visionOriginPoint.right);
    //     Vector3 upRayDirection = upRayRotation * _visionOriginPoint.forward;
    //     Vector3 downRayDirection = downRayRotation * _visionOriginPoint.forward;
    //     Gizmos.DrawLine(_visionOriginPoint.position, _visionOriginPoint.position + upRayDirection * _visionRange.Value);
    //     Gizmos.DrawLine(_visionOriginPoint.position, _visionOriginPoint.position + downRayDirection * _visionRange.Value);

    //     //Enemy in sight
    //     Gizmos.color = Color.magenta;
    //     if(EnemyInSight != null)
    //     {
    //         Gizmos.DrawLine(_visionOriginPoint.position,EnemyInSight.bounds.center);
    //         Gizmos.DrawSphere(EnemyInSight.bounds.center,0.05f);
    //     }
    // }
}

