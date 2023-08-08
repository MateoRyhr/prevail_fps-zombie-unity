using UnityEngine;
using UnityEngine.Events;

public class ObjectUser : MonoBehaviour
{
    [SerializeField] private Transform _objectToUseParent;
    private Usable _objectToUse;
    public Usable Usable => _objectToUse;

    public UnityEvent OnUse;

    public void UseObject()
    {
        if(_objectToUse.Equipped)
        {
            OnUse?.Invoke();
           _objectToUse.Use();
        }
    }

    public void UseObjectRepeatedly()
    {
        if(_objectToUse.Equipped)
        {
            OnUse?.Invoke();
           _objectToUse.UseRepeatedly();
        }
    }

    public void UpdateObject()
    {
        _objectToUse = _objectToUseParent.GetComponentInChildren<Usable>();
    }
}
