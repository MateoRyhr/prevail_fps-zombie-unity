using UnityEngine;

public class StateIdle : MonoBehaviour, IState
{
    [SerializeField] private Vector2Controller _movement;

    // public StateIdle(EntityDirectionController3D movementController){
    //     _movement = movementController;
    // }

    public void OnEnter()
    {
        _movement.Value = Vector2.zero;
    }

    public void Tick(){}
    public void OnExit(){}
}