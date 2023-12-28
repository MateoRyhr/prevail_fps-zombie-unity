using UnityEngine;
using UnityEngine.Events;

public abstract class MeleeWeapon : Weapon
{
    public MeleeAttack[] attacks;
    [SerializeField] MeleeWeaponData _meleeWeaponData;
    public MeleeWeaponData MeleeWeaponData => _meleeWeaponData;
    [SerializeField] private LayerMask _impactableLayers;
    public LayerMask ImpactableLayers => _impactableLayers;
    public bool IsAttacking { get; private set; }
    public override bool CanBeUsed => true;

    public UnityEvent OnMeleeAttackStart;
    public UnityEvent OnMeleeAttackHitStart;
    public UnityEvent OnMeleeAttackHitFinished;
    public UnityEvent OnMeleeAttackFinished;

    public MeleeAttack LastAttack { get; private set; }

    private void OnEnable() {
        IsAttacking = false;
    }

    public override void Use()
    {
        if(IsAttacking) return;
        IsAttacking = true;
        int randomAttack = Random.Range(0,attacks.Length);
        MeleeAttack attack = attacks[randomAttack];
        LastAttack = attack;

        OnUse?.Invoke();
        OnMeleeAttackStart?.Invoke();
        attack.OnAttackStart?.Invoke();

        this.InvokeScaledDeltaTime(() => {
            HitStart();
            OnMeleeAttackHitStart?.Invoke();
            attack.OnAttackHitStart?.Invoke();
        },attack.TimeUntilHitStart);

        this.InvokeScaledDeltaTime(() => {
            HitEnd();
            OnMeleeAttackHitFinished?.Invoke();
            attack.OnAttackHitFinished?.Invoke();
        },attack.TimeUntilHitFinished);

        this.InvokeScaledDeltaTime(() => {
            OnMeleeAttackFinished?.Invoke();
            attack.OnAttackFinished?.Invoke();
            IsAttacking = false;
        },attack.TimeUntilAttackFinished);
    }
    
    public abstract void HitStart();
    public abstract void HitEnd();
}
