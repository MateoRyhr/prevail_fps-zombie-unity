using UnityEngine;
using UnityEngine.Events;

public class Reparable : MonoBehaviour 
{
    [SerializeField] private GameObject _repairerGetterContainer;
    [SerializeField] private GameObject _reparableHealthContainer;

    public UnityEvent OnARepairStart;
    public UnityEvent OnARepairComplete;

    private IAmount _reparableHealthGetter;
    public Amount _reparableHealth { get => _reparableHealthGetter.Amount; }

    IGameObject _repairerGetter;

    private void Awake()
    {
        _repairerGetter = _repairerGetterContainer.GetComponent<IGameObject>();
        _reparableHealthGetter = _reparableHealthContainer.GetComponent<IAmount>();
    }

    public void StartARepair()
    {
        if(_reparableHealth.Value >= _reparableHealth.MaxValue) return;
        Repairer repairer = _repairerGetter.GameObject.GetComponent<Repairer>();
        repairer.StartARepair(this);
        OnARepairStart?.Invoke();
    }
}
