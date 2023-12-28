using UnityEngine;
using UnityEngine.Events;

public class ObjectUser : MonoBehaviour
{
    [SerializeField] private Transform _objectToUseParent;
    private Usable _objectToUse;
    public Usable Usable => _objectToUse;

    public UnityEvent OnUse;
    public UnityEvent OnCantUse;
    public UnityEvent OnUseFinish;

    public void UseObject()
    {
        if(_objectToUse.Equipped)
        {
            if(_objectToUse.CanBeUsed)
            {
                OnUse?.Invoke();
                _objectToUse.Use();
                this.Invoke(() => OnUseFinish?.Invoke(),_objectToUse.TimeUsing);
            }
            else
            {
                OnCantUse?.Invoke();
            }
        }
    }

    public void UseObjectRepeatedly()
    {
        if(_objectToUse.Equipped)
        {
            if(_objectToUse.CanBeUsed)
            {
                OnUse?.Invoke();
                _objectToUse.UseRepeatedly();
            }
        }
    }

    public void UpdateObject()
    {
        _objectToUse = _objectToUseParent.GetComponentInChildren<Usable>();
    }
}
