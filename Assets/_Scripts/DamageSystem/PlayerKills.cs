using UnityEngine;
using UnityEngine.Events;

public class PlayerKills : MonoBehaviour, IAmount
{
    public Amount Kills;
    public Amount Amount { get => Kills; }

    public UnityEvent OnKillsModified;
    // public UnityEvent OnAddScore;
    // public UnityEvent OnRestScore;

    private void Awake()
    {
        Kills = new Amount(0,0,Mathf.Infinity);
        Kills.OnAmountModified += OnKillsModified.Invoke;
        // Kills.OnAddToTheAmount += OnAddScore.Invoke;
        // Kills.OnSubstractToTheAmount += OnRestScore.Invoke;
    }

    public void Add(float amount)
    {
        // Debug.Log("Kill added"); //LLego hasta acá
        Kills.Add(amount);
    }
}
