using UnityEngine;
using UnityEngine.Events;

public abstract class Usable : Equipable
{
    [SerializeField] private float _timeToUse;
    [SerializeField] private float _timeUsing;
    
    public UnityEvent OnUse;
    
    public abstract bool IsRepeatedlyUsable { get; }
    
    public abstract void Use();

    public void UseRepeatedly()
    {
        if(IsRepeatedlyUsable)
            Use();
    }
}