using System;
using UnityEngine;

public class AIMeleeEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _idle;
    [SerializeField] private GameObject _randomPatrolling;
    [SerializeField] private GameObject _meleeCombat;
    [SerializeField] private AIEntityData _aiData;

    [Header("Behaviours settings")]
    [SerializeField] private bool _onStartStayIdle;

    private StateMachine _stateMachine;

    void Awake()
    {
        _stateMachine = new StateMachine();

        IState idle = _idle.GetComponent<IState>();
        IState randomPatrolling = _randomPatrolling.GetComponent<IState>();
        IState meleeCombat = _meleeCombat.GetComponent<IState>();

        At(idle,randomPatrolling,() => _onStartStayIdle == false);
        At(meleeCombat,randomPatrolling,() => !_aiData.HasTarget);
        _stateMachine.AddAnyTransition(meleeCombat,() => _aiData.EnemyDetector.EnemyInSight);

        _stateMachine.SetState(idle);
    }

    void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
    
    void Update() => _stateMachine.Tick();
}
