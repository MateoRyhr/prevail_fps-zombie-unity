using TMPro;
using UnityEngine;

public class AmountOnUI : MonoBehaviour
{
    [Tooltip("A script that implements IAmount")]
    [SerializeField] private GameObject _amountContainer;
    [SerializeField] TextMeshProUGUI _text;

    private IAmount _amount;

    private void Awake() => _amount = _amountContainer.GetComponent<IAmount>();
    public void UpdateUI() => _text.text = $"{_amount.Amount.Value}";
}
