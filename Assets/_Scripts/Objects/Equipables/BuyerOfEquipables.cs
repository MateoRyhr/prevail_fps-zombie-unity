using UnityEngine;
using UnityEngine.Events;

public class BuyerOfEquipables : MonoBehaviour
{
    [Tooltip("A script that implements IAmount")]
    [SerializeField] private GameObject moneyContainer;
    [SerializeField] private Equipper _equipper;
    public Equipper Equipper { get => _equipper; }
    
    public UnityEvent OnBuySucceed;
    public UnityEvent OnBuyFailed;

    private IAmount _money;

    private void Awake()
    {
        _money = moneyContainer.GetComponent<IAmount>();    
    }

    public bool Buy(Equipable equipable, float cost)
    {
        if(CanBuyIt(cost))
        {
            _money.Amount.Substract(cost);
            _equipper.Add(equipable);
            OnBuySucceed?.Invoke();
            return true;
        }
        else
        {
            OnBuyFailed?.Invoke();
            return false;
        }
    }

    bool CanBuyIt(float cost) => cost < _money.Amount.Value;
}
