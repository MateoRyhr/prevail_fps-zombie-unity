using System;
using UnityEngine;

public class AIZombie : MonoBehaviour
{
    [SerializeField] private GameObject _chaseState;
    [SerializeField] private AIEntityData _aiData;

    // [Header("Behaviours settings")]
    // [SerializeField] private bool _onStartStayIdle;

    private StateMachine _stateMachine;

    void Start()
    {
        _stateMachine = new StateMachine();

        IState chaseState = _chaseState.GetComponent<IState>();

        _stateMachine.SetState(chaseState);
    }

    void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
    
    void Update() => _stateMachine.Tick();
}
