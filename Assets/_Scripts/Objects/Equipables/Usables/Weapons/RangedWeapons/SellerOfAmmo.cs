using UnityEngine;

public class SellerOfAmmo : MonoBehaviour
{
    [SerializeField] private int _amountOfAmmo;
    [SerializeField] private GameObject _buyerGetterContainer;

    IGameObject _buyerGetter;

    private void Awake() => _buyerGetter = _buyerGetterContainer.GetComponent<IGameObject>();

    public void SellAmmo()
    {
        BuyerOfAmmo buyer = _buyerGetter.GameObject.GetComponent<BuyerOfAmmo>();
        buyer.BuyAmmo(_amountOfAmmo);
    }
}
