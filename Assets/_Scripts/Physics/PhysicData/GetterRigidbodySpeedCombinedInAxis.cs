using UnityEngine;

public class GetterRigidbodySpeedCombinedInAxis : MonoBehaviour, IFloat
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] bool _useX, _useY, _useZ;
    public float Value { get => GetSpeed(); set => Value = value; }
    
    private float GetSpeed() {
        float speed = 0f;
        if(_useX) speed += Mathf.Abs(_rigidBody.velocity.x);
        if(_useY) speed += Mathf.Abs(_rigidBody.velocity.y);
        if(_useZ) speed += Mathf.Abs(_rigidBody.velocity.z);
        return speed;
    }
}