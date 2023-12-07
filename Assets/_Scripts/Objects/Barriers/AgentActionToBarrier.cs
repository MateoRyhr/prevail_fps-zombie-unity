using UnityEngine;
using UnityEngine.Events;

public class AgentActionToBarrier : MonoBehaviour
{
    public UnityEvent OnActionOnBarrier;
    public UnityEvent OnActionOnNoBarrier;

    public void ActionOnBarrier()
    {
        OnActionOnBarrier?.Invoke();
    }

    public void ActionOnNoBarrier()
    {
        OnActionOnNoBarrier?.Invoke();
    }
}
