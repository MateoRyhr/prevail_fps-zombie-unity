using UnityEngine;
using UnityEngine.Events;

public class SellerOfEquipables : MonoBehaviour
{
    [SerializeField] private Equipable _equipableOnSale;
    [SerializeField] private float _cost;
    [SerializeField] private GameObject _buyerGetterContainer;

    public UnityEvent OnSellSucceed;
    public UnityEvent OnSellFailed;

    IGameObject _buyerGetter;

    private void Awake() => _buyerGetter = _buyerGetterContainer.GetComponent<IGameObject>();

    public void SellEquipable()
    {
        BuyerOfEquipables buyer = _buyerGetter.GameObject.GetComponent<BuyerOfEquipables>();
        if(buyer.Buy(_equipableOnSale,_cost))
            OnSellSucceed?.Invoke();
        else
            OnSellFailed?.Invoke();
    }
}
