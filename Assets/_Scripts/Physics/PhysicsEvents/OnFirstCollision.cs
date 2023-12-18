using UnityEngine;
using UnityEngine.Events;

// [RequireComponent(typeof(Rigidbody))]
public class OnFirstCollision : MonoBehaviour
{
    [SerializeField] LayerMask _avoidLayers;
    public UnityEvent OnFirstCollisionEvent;

    private bool _hasCollided;

    private void Awake()
    {
        _hasCollided = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(_hasCollided) return;
        if(LayerUtil.LayerContains(_avoidLayers,other.gameObject.layer)) return;
        _hasCollided = true;
        OnFirstCollisionEvent?.Invoke();
    }

    public void Reset()
    {
        _hasCollided = false;
    }
}
