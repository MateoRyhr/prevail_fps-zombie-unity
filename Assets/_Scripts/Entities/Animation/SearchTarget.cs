using UnityEngine;
using UnityEngine.Events;

public class SearchTarget : MonoBehaviour, ITransform
{
    [SerializeField] private string _targetName;
    private ICollider _colliderGetter;

    Transform ITransform.Value { get => _targetTransform; set => _targetTransform = value; }
    private Transform _targetTransform;

    public UnityEvent OnTargetSetted;

    private void Awake()
    {
        _colliderGetter = GetComponent<ICollider>();
    }

    public void SetTarget()
    {
        Target[] targets = _colliderGetter.Collider.transform.root.GetComponentsInChildren<Target>();
        foreach (Target target in targets)
        {
            if(target.Name == _targetName)
            {
                _targetTransform = target.transform;
                OnTargetSetted?.Invoke();
            }
        }
    }
}
