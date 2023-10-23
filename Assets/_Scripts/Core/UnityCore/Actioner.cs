using System;
using UnityEngine;

public class Actioner : MonoBehaviour
{
    public void PerformAction(Action action, float time)
    {
        this.Invoke(() => action.Invoke(),time);
    }
}
