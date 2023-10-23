using UnityEngine;

public class AIEntityData : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private FloatVariable _timeBeforeAttack;
    [SerializeField] private FloatVariable _timeToLostEnemy;
    [SerializeField] private AIEnemyDetector _enemyDetector;

    public Collider Collider { get => _collider; }
    public float TimeBeforeAttack { get => _timeBeforeAttack.Value; }
    public float TimeToLostEnemy { get => _timeToLostEnemy.Value; }    
    public AIEnemyDetector EnemyDetector { get => _enemyDetector; }
    public bool HasTarget { get; set; }

    const float SMALL_AMOUNT = 0.1f;

    public bool IsGroundInFront() => Physics.Raycast(FowardPointOnTheFloor(),Vector2.down,SMALL_AMOUNT * 2,_groundLayer);

    public bool IsWallInFront() => Physics.Raycast(FowardPointOnTheFloor(),_collider.transform.forward,SMALL_AMOUNT,_groundLayer);

    private Vector3 FowardPointOnTheFloor(){
        return new Vector3(
            _collider.transform.position.x,
            _collider.transform.position.y + SMALL_AMOUNT,  //From foots A small amount up to hit the ground on go down.
            _collider.transform.position.z + _collider.bounds.max.z
        );
    }
}
