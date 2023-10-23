using UnityEngine;

public class StateRandomPatrolling : MonoBehaviour, IState
{
    [SerializeField] private Vector2Controller _movementDirectionController;
    [SerializeField] private Vector2Controller _lookDirectionController;
    [SerializeField] private AIEntityData _aiData;
    [SerializeField] private float _minTime;
    [SerializeField] private float _maxTime;

    private float _timeUntilNextMovement;

    public void OnEnter(){}

    public void Tick()
    {
        if(_timeUntilNextMovement <= 0f || !_aiData.IsGroundInFront() || _aiData.IsWallInFront()){
            SetMovement();
            _timeUntilNextMovement = Random.Range(_minTime,_maxTime);
        }
        _timeUntilNextMovement -= Time.deltaTime * Time.timeScale;
    }

    public void OnExit(){}

    private void SetMovement(){
        float random = Random.Range(0f,1f);
        Vector2 previousDirection = _lookDirectionController.Value;
        //If can't walk forward, stay look at the same direction or look in the opposite direction
        if(!_aiData.IsGroundInFront() || _aiData.IsWallInFront()){
            if(_aiData.IsWallInFront())
                _lookDirectionController.Value = _aiData.Collider.transform.forward * -1;
            else
                _lookDirectionController.Value = random < .5f ? _aiData.Collider.transform.forward : _aiData.Collider.transform.forward * -1;
        }else{//Otherwise pick random direction
            if(random < .33f) _lookDirectionController.Value = _aiData.Collider.transform.forward;
            else _lookDirectionController.Value = new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f));
        }
        if(previousDirection == _lookDirectionController.Value)
            _movementDirectionController.Value = Vector2.zero;
        else
            _movementDirectionController.Value = new Vector2(0f,1f);
    }
}
