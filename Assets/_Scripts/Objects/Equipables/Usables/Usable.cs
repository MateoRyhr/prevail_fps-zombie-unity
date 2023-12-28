using UnityEngine;
using UnityEngine.Events;

public abstract class Usable : Equipable
{
    [SerializeField] private float _timeToUse;
    public float TimeToUse { get => _timeToUse;}
    [SerializeField] private float _timeUsing;
    public float TimeUsing { get => _timeUsing;}
    
    public UnityEvent OnUse;
    
    public abstract bool IsRepeatedlyUsable { get; }
    public abstract bool CanBeUsed { get; }
    
    public abstract void Use();

    public void UseRepeatedly()
    {
        if(IsRepeatedlyUsable)
            Use();
    }
}