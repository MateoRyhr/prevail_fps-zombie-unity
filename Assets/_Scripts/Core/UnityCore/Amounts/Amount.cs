using System;
using UnityEngine;

public class Amount
{
    public float Value { get; private set; }
    public float MaxValue { get; private set; }
    public float MinValue { get; private set; }

    public Action OnAddToTheAmount;
    public Action OnSubstractToTheAmount;
    public Action OnAmountModified;

    public Amount(float initialValue, float minValue,float maxValue)
    {
        Value = initialValue;
        MinValue = minValue;
        MaxValue = maxValue;
    }

    public void Add(float value){
        Value = Mathf.Clamp(Value + value,MinValue,MaxValue);
        OnAddToTheAmount?.Invoke();
        OnAmountModified?.Invoke();
    }

    public void Substract(float value){
        Value = Mathf.Clamp(Value - value,MinValue,MaxValue);
        OnSubstractToTheAmount?.Invoke();
        OnAmountModified?.Invoke();
    }

    public void SetAmount(float value){
        Value = Mathf.Clamp(value,MinValue,MaxValue);
        OnAmountModified?.Invoke();
    }
}
