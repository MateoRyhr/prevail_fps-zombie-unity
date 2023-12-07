using UnityEngine;
using UnityEngine.Events;

public class Repairer : MonoBehaviour
{
    public UnityEvent OnARepairStart;
    public UnityEvent OnARepairComplete;

    public void StartARepair(Reparable reparable)
    {
        OnARepairStart?.Invoke();
        OnARepairComplete.AddListener(reparable.OnARepairComplete.Invoke);
    }

    public void CompleteARepair()
    {
        OnARepairComplete?.Invoke();
        OnARepairComplete.RemoveAllListeners();
    }

    public void RemoveListeners()
    {
        OnARepairComplete.RemoveAllListeners();
    }
}
