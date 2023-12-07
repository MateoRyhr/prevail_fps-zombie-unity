using UnityEngine;
using UnityEngine.Events;

public class LinkBarrier : MonoBehaviour, IAmount
{
    [SerializeField] private int _maxBarriersAmount;
    [SerializeField] private int _startBarriers;
    // [SerializeField] private string _agentColliderTag;

    public UnityEvent OnNoBarrier;
    public UnityEvent OnBarrier;

    public Amount Amount { get => _amount; set => _amount = value; }
    private Amount _amount;
 
    private void Awake() => _amount = new Amount(_startBarriers,0,_maxBarriersAmount);

    public void Substract(int amount)
    {
        _amount.Substract(amount);
        if(_amount.Value == 0)
            OnNoBarrier?.Invoke();
    }

    public void Add(int amount)
    {
        if(_amount.Value <= 0)
            OnBarrier?.Invoke();
        _amount.Add(amount);
    }

    private void OnTriggerEnter(Collider other)
    {   
        AgentActionToBarrier agentActionToBarrier = other.GetComponent<AgentActionToBarrier>();
        OnNoBarrier.AddListener(agentActionToBarrier.ActionOnNoBarrier);
        if(_amount.Value > 0)
        {
            agentActionToBarrier.ActionOnBarrier();
        }
        else
        {
            agentActionToBarrier.ActionOnNoBarrier();
        }
    }
}
