using UnityEngine;
using UnityEngine.Events;

public class BuyerOfEquipables : MonoBehaviour
{
    [SerializeField] private Equipper _equipper;
    public Equipper Equipper { get => _equipper; }
    
    public UnityEvent OnBuy;

    public void AddEquipable(Equipable equipable)
    {
        _equipper.Add(equipable);
        OnBuy?.Invoke();
    }
}
