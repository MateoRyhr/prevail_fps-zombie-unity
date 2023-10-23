using UnityEngine;
using UnityEngine.AI;

public class StateAlwaysChaseEnemies : MonoBehaviour, IState
{
    [SerializeField] private AIEntityData _aiData;
    [SerializeField] private Vector2Controller _movementController;
    [SerializeField] private Vector2Controller _lookController;
    [SerializeField] private Equipper _weaponEquipper;
    [SerializeField] private ObjectUser _weaponUser;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Vector3Variable[] enemiesPositions;

    private bool _isAttacking;
    private MeleeWeapon _meleeWeapon;
    private float _timeUntilAttack = 0f;

    private NavMeshPath _path;

    public void OnEnter()
    {
        _timeUntilAttack = _aiData.TimeBeforeAttack;
        _path = new NavMeshPath();
        _meleeWeapon = (MeleeWeapon)_weaponEquipper.Equipped;
    }

    public void OnExit(){}

    public void Tick()
    {
        /*
                                                    */
        if(!_agent.enabled) return;
        FollowEnemy();
        if(! CanAttackEnemy())
        {
            Move();
        }
        else
        {
            Stop();
            // LookAtEnemy();
            Attack();
        }
    }

    void FollowEnemy()
    {
        _agent.CalculatePath(GetClosestEnemy(),_path);
        if(_path.corners.Length < 2) return;
        Vector3 direction = (_path.corners[1] - _path.corners[0]).normalized;
        _lookController.Value = new Vector2(direction.x,direction.z);
    }

    void Attack()
    {
        if(_timeUntilAttack <= 0f)
        {
            _isAttacking = true;
            _weaponUser.UseObject();
            _timeUntilAttack = _aiData.TimeBeforeAttack + _meleeWeapon.LastAttack.TimeUntilAttackFinished;
            _aiData.InvokeScaledDeltaTime(() => _isAttacking = false,_aiData.TimeBeforeAttack + _meleeWeapon.LastAttack.TimeUntilAttackFinished);
        }
        else
        {
            _timeUntilAttack -= Time.deltaTime * Time.timeScale;
        }
    }

    void LookAtEnemy()
    {
        Vector3 direction = (GetClosestEnemy() - transform.position).normalized;
        _lookController.Value = new Vector2(direction.x,direction.z);
    }

    Vector3 GetClosestEnemy()
    {
        float closestEnemyDistance = Mathf.Infinity;
        Vector3 closestEnemy = Vector3.zero;
        foreach (var enemyPosition in enemiesPositions)
        {
            float distanceToEnemy = DistanceTo(enemyPosition.Value);
            if(distanceToEnemy < closestEnemyDistance)
            {
                closestEnemyDistance = distanceToEnemy;
                closestEnemy = enemyPosition.Value;
            }
        }
        return closestEnemy;
    }

    void Move() => _movementController.Value = Forward();
    void Stop() => _movementController.Value = Vector2.zero;
    float DistanceTo(Vector3 position) => Mathf.Abs(Vector3.Distance(_aiData.Collider.transform.position,position));
    float AttackRange() => _meleeWeapon.MeleeWeaponData.attackRange;
    bool CanAttackEnemy() => DistanceTo(GetClosestEnemy()) < AttackRange();
    Vector2 Forward() => new Vector2(0f,1f);

    // private void OnDrawGizmos() {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(_path.corners[1],.1f);
    //     Gizmos.DrawSphere(GetClosestEnemy(),.25f);
    // }
}
