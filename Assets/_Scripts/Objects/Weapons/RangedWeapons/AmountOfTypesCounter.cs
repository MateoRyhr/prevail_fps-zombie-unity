using System;
using UnityEngine;

public class AmountOfTypesCounter
{
    protected Enum Type;
    private int[] _amounts;
    public int[] Amounts => _amounts;
    protected int currentAmountIndex;
    
    public AmountOfTypesCounter(Enum typeToCount,int[] initialAmounts)
    {
        Type = typeToCount;
        _amounts = initialAmounts;
    }

    public void Add(int index, int amount) => _amounts[index] += amount;
    public void Substract(int index, int amount) => _amounts[index] -= amount;
}

