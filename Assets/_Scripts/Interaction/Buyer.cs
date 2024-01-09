using UnityEngine;
using UnityEngine.Events;

public class Buyer : MonoBehaviour
{
    [Tooltip("A script that implements IAmount")]
    [SerializeField] private GameObject moneyContainer;

    public UnityEvent OnBuySucceed;
    public UnityEvent OnBuyFailed;

    private IAmount _money;

    private void Awake()
    {
        _money = moneyContainer.GetComponent<IAmount>();    
    }

    public bool Buy(float cost)
    {
        if(CanBuyIt(cost))
        {
            _money.Amount.Substract(cost);
            OnBuySucceed?.Invoke();
            return true;
        }
        else
        {
            OnBuyFailed?.Invoke();
            return false;
        }
    }
    
    bool CanBuyIt(float cost) => cost <= _money.Amount.Value;
}
