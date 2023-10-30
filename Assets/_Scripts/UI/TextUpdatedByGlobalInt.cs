using TMPro;
using UnityEngine;

public class TextUpdatedByGlobalInt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private IntVariable _value;

    public void Update()
    {
        _text.text = _value.Value.ToString();
    }
}
