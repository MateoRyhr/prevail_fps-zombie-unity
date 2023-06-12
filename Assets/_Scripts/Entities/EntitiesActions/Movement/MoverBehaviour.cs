using UnityEngine;

public abstract class MoverBehaviour : MonoBehaviour
{
    [SerializeField] private protected GameObject _directionGameObject;
    [SerializeField] private protected FloatVariable _maxSpeed;

    private protected IMover _mover;
    private protected IVector2 _direction;

    private protected virtual void Awake()
    {
        _direction = _directionGameObject.GetComponent<IVector2>();        
    }
}