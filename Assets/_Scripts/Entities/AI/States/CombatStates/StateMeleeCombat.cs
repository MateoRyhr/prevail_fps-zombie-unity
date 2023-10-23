using UnityEngine;
using UnityEngine.Events;

public class StateMeleeCombat : MonoBehaviour, IState
{
    [SerializeField] private AIEntityData _aiData;
    [SerializeField] private Vector2Controller _movementController;
    [SerializeField] private Vector2Controller _lookController;
    [SerializeField] private Equipper _weaponEquipper;
    [SerializeField] private ObjectUser _weaponUser;

    private float _timeToLostEnemy;
    private float _timeUntilLostEnemy = 0f;

    private Vector3 _enemyLastPosition;
    private float _timeUntilAttack = 0f;

    private bool _isAttacking;
    // bool _enemyLastPositionReached;

    private MeleeWeapon _meleeWeapon;

    public UnityEvent OnEnterState;
    public UnityEvent OnExitState;

    public void OnEnter()
    {
        OnEnterState?.Invoke();
        _timeUntilAttack = _aiData.TimeBeforeAttack;
        if(!_weaponEquipper.Equipped || !(_weaponEquipper.Equipped is MeleeWeapon))
            Debug.Log($"AI: Entity have no weapon equipped");
        else
            _meleeWeapon = (MeleeWeapon)_weaponEquipper.Equipped;
    }

    public void Tick()
    {   
        if(_aiData.EnemyDetector.EnemyInSight)
        {
            _enemyLastPosition = _aiData.EnemyDetector.EnemyInSight.transform.root.position;
            if(DistanceToTarget() > _meleeWeapon.MeleeWeaponData.attackRange) FollowEnemy();
            else Attack();
        }
        else
        {
            FollowEnemyLastPosition();
        }
    }

    public void OnExit() => OnExitState?.Invoke();

    void FollowEnemy()
    {
        _lookController.Value = new Vector2(DirectionToTarget().x,DirectionToTarget().z);
        if(!_isAttacking) _movementController.Value = Forward();
    }

    void FollowEnemyLastPosition()
    {
        if(DistanceToTarget() > 0.2f)
        {
            _lookController.Value = new Vector2(DirectionToTarget().x,DirectionToTarget().z);
            _movementController.Value = Forward();
        }
        else
        {
            _lookController.Value = new Vector2(_aiData.Collider.transform.forward.x,_aiData.Collider.transform.forward.z);
            _movementController.Value = Vector2.zero;
        }
    }

    void Attack()
    {
        _movementController.Value = Vector2.zero;
        _lookController.Value = new Vector2(DirectionToTarget().x,DirectionToTarget().z);
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

    float DistanceToTarget() => Vector3.Distance(_enemyLastPosition,_aiData.Collider.transform.position);
    Vector3 DirectionToTarget() => _enemyLastPosition - _aiData.Collider.transform.position;
    Vector2 Forward() => new Vector2(0f,1f);
}
