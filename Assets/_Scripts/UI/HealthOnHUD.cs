using UnityEngine;
using TMPro;

public class HealthOnHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] HealthEntity _entityHealth;

    public void UpdateHealth()
    {
        _text.text = $"{_entityHealth.Health.Value}";
    }
}
