using UnityEngine;

public class PositionOnScriptable : MonoBehaviour
{
    [SerializeField] private Transform _transformToGetPosition;
    [SerializeField] private Vector3Variable _dataContainer;

    private void Update() => _dataContainer.Value = _transformToGetPosition.position;
}
