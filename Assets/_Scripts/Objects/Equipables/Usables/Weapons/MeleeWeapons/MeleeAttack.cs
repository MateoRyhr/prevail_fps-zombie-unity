using UnityEngine;
using UnityEngine.Events;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private float _timeUntilHitStart;
    [SerializeField] private float _timeUntilHitFinished;
    [SerializeField] private float _timeUntilAttackFinished;

    public float TimeUntilHitStart { get => _timeUntilHitStart; }
    public float TimeUntilHitFinished { get => _timeUntilHitFinished; }
    public float TimeUntilAttackFinished { get => _timeUntilAttackFinished; }
    
    public UnityEvent OnAttackStart;
    public UnityEvent OnAttackHitStart;
    public UnityEvent OnAttackHitFinished;
    public UnityEvent OnAttackFinished;
}
