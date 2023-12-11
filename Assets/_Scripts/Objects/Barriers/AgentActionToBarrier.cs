using UnityEngine;
using UnityEngine.Events;

public class AgentActionToBarrier : MonoBehaviour
{
    [SerializeField] Vector2Controller _lookController;

    public UnityEvent OnActionOnBarrier;
    public UnityEvent OnActionOnNoBarrier;

    public void ActionOnBarrier(Vector3 barrierPosition)
    {
        Vector3 direction = barrierPosition - transform.position;
        _lookController.Value = new Vector2(direction.x,direction.z);
        OnActionOnBarrier?.Invoke();
    }

    public void ActionOnNoBarrier()
    {
        OnActionOnNoBarrier?.Invoke();
    }
}
