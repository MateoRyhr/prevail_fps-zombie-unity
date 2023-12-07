using UnityEngine;
using UnityEngine.Events;

public class LinkBarrierElement : MonoBehaviour
{
    [SerializeField] private LinkBarrier _linkBarrier;
    [SerializeField] private int _barrierId;

    public UnityEvent OnRemove;
    public UnityEvent OnAdd;

    public int BarrierID { get => _barrierId; }

    public void RemoveElement()
    {
        _linkBarrier.Substract(1);
        OnRemove?.Invoke();
    }

    public void AddElement()
    {
        _linkBarrier.Add(1);
        OnAdd?.Invoke();
    }

    public void SetBarrier(LinkBarrier barrier)
    {
        _linkBarrier = barrier;
    }
}
