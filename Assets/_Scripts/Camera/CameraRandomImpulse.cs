using UnityEngine;
using Cinemachine;

public class CameraRandomImpulse : MonoBehaviour
{
    [SerializeField] private Vector3 _minImpulse;
    [SerializeField] private Vector3 _maxImpulse;
    [SerializeField] private CinemachineImpulseSource _impulseSource;

    public void GenerateRandomImpulseDoubleDirectionValues()
    {
        Vector3 newImpulseValue = new(
            Random.Range(_minImpulse.x,_maxImpulse.x) * RandomDirection(),
            Random.Range(_minImpulse.y,_maxImpulse.y) * RandomDirection(),
            Random.Range(_minImpulse.z,_maxImpulse.z) * RandomDirection()
        );
        _impulseSource.m_DefaultVelocity = newImpulseValue;
        _impulseSource.GenerateImpulse();
    }

    public void GenerateRandomImpulseSingleDirectionValue()
    {
        Vector3 newImpulseValue = new(
            Random.Range(_minImpulse.x,_maxImpulse.x),
            Random.Range(_minImpulse.y,_maxImpulse.y),
            Random.Range(_minImpulse.z,_maxImpulse.z)
        );
        _impulseSource.m_DefaultVelocity = newImpulseValue;
        _impulseSource.GenerateImpulse();
    }

    private int RandomDirection() => Random.Range(0,2) == 0 ? 1 : -1;
}
