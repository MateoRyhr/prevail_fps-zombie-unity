using UnityEngine;
using UnityEngine.Events;

public class Seller : MonoBehaviour
{
    [SerializeField] private float _cost;
    [SerializeField] private GameObject _buyerGetterContainer;

    public UnityEvent OnSellSucceed;
    public UnityEvent OnSellFailed;

    IGameObject _buyerGetter;

    private void Awake() => _buyerGetter = _buyerGetterContainer.GetComponent<IGameObject>();

    public void Sell()
    {
        Buyer buyer = _buyerGetter.GameObject.GetComponent<Buyer>();
        if(buyer.Buy(_cost))
            OnSellSucceed?.Invoke();
        else
            OnSellFailed?.Invoke();
    }
}
