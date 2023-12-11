using UnityEngine;
using UnityEngine.Events;

public class PlayerHeadshots : MonoBehaviour, IAmount
{
    public Amount Headshots;
    public Amount Amount { get => Headshots;}

    public UnityEvent OnHeadshotsModified;
    // public UnityEvent OnAddScore;
    // public UnityEvent OnRestScore;

    private void Awake()
    {
        Headshots = new Amount(0,0,Mathf.Infinity);
        Headshots.OnAmountModified += OnHeadshotsModified.Invoke;
        // Headshots.OnAddToTheAmount += OnAddScore.Invoke;
        // Headshots.OnSubstractToTheAmount += OnRestScore.Invoke;
    }

    public void Add(float amount) => Headshots.Add(amount);
}
