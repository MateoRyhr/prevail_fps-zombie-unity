using System;

public class Amount
{
    public float Value { get; private set; }
    public float MaxValue { get; private set; }

    public Action OnAddToTheAmount;
    public Action OnSubstractToTheAmount;
    public Action OnAmountModified;

    public Amount(float initialValue, float maxValue)
    {
        Value = initialValue;
        MaxValue = maxValue;
    }

    public void Add(float value){
        Value += value;
        OnAddToTheAmount?.Invoke();
        OnAmountModified?.Invoke();
    }

    public void Substract(float value){
        Value -= value;
        OnSubstractToTheAmount?.Invoke();
        OnAmountModified?.Invoke();
    }

    public void SetAmount(float value){
        Value = value;
        OnAmountModified?.Invoke();
    }
}
