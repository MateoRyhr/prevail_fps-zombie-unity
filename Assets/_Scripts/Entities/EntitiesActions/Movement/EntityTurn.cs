using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityTurn : MonoBehaviour
{
    [SerializeField] private Collider _movementCollider;
    [SerializeField] private Vector2Controller _directionController;
    [SerializeField] private FloatVariable _rotationSpeed;

    private void FixedUpdate()
    {
        Turn();
    }

    void Turn()
    {
        Vector3 direction = new Vector3(_directionController.Value.x,0,_directionController.Value.y);
        if(direction == Vector3.zero)
            direction = _movementCollider.transform.forward;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        _movementCollider.transform.rotation = Quaternion.Slerp(
                _movementCollider.transform.rotation,
                targetRotation,
                _rotationSpeed.Value * Time.fixedDeltaTime
        );
    }
}
