using TMPro;
using UnityEngine;

public class UIInteractionMessage : MonoBehaviour
{
    [SerializeField] private Interactor _interactor;
    [SerializeField] private TextMeshProUGUI _text;

    public void SetInteractionText()
    {
        _text.text = _interactor.Interactable.Message;
    }
}
