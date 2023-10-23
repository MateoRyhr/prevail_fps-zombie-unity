using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private string _targetName;
    public string Name => _targetName;
}
