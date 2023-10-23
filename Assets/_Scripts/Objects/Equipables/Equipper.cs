using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Equipper : MonoBehaviour
{
    private List<Equipable> _equipables = new List<Equipable>();
    private int _equippedIndex;
    public Equipable Equipped => _equipables[_equippedIndex];
    [SerializeField] private Transform _parentOnEquipping;
    [SerializeField] private Transform _parentOnUnequipping;

    public UnityEvent OnEquip;
    public UnityEvent OnUnequip;

    private void Awake() => RegisterCurrentEquipables();

    public void Add(Equipable equipable)
    {
        if(!_equipables.Contains(equipable))
            _equipables.Add(equipable);
    }

    public void Remove(Equipable equipable)
    {
        if(_equipables.Contains(equipable))
            _equipables.Remove(equipable);
    }

    public void Equip(int n)
    {
        if(n < 0 || n >= _equipables.Count || n == _equippedIndex) return; 
        if(_equippedIndex >= 0)
        {
            this.InvokeScaledDeltaTime(() =>
                {
                    _equipables[n].Equip(_parentOnEquipping);
                    _equippedIndex = n;
                    OnEquip?.Invoke();
                },
                Equipped.TimeUnequipping + Time.deltaTime
            );
            OnUnequip?.Invoke();
            Equipped.Unequip(_parentOnUnequipping);
        }
        else
        {
            _equipables[n].Equip(_parentOnEquipping);
            _equippedIndex = n;
            OnEquip?.Invoke();
        }
    }

    public void EquipNext()
    {
        if(_equipables.Count <= 1) return;
        int next = NextEquipable();
        this.InvokeScaledDeltaTime(() => 
            {
                _equipables[next].Equip(_parentOnEquipping);
                OnEquip?.Invoke();
            },
            Equipped.TimeUnequipping + Time.deltaTime
        );
        OnUnequip?.Invoke();
        Equipped.Unequip(_parentOnUnequipping);
        _equippedIndex = next;
    }

    public void EquipPrevious()
    {
        if(_equipables.Count <= 1) return;
        int previous = PreviousEquipable();
        this.InvokeScaledDeltaTime(() =>
            {
                _equipables[previous].Equip(_parentOnEquipping);
                OnEquip?.Invoke();
            },
            Equipped.TimeUnequipping + Time.deltaTime
        );
        OnUnequip?.Invoke();
        Equipped.Unequip(_parentOnUnequipping);
        _equippedIndex = previous;
    }

    int NextEquipable() => _equippedIndex + 1 >= _equipables.Count ? 0 : _equippedIndex + 1;
    int PreviousEquipable() => _equippedIndex - 1 < 0 ? _equipables.Count - 1 : _equippedIndex - 1;

    void RegisterCurrentEquipables()
    {
        _equippedIndex = -1;
        Equipable equipped = _parentOnEquipping.GetComponentInChildren<Equipable>();
        if(equipped != null)
        {
            Add(equipped);
        }
        for(int i = 0; i < _parentOnUnequipping.childCount;i++)
        {
            Equipable equipable = _parentOnUnequipping.GetChild(i).GetComponent<Equipable>();
            if(equipable)
            {
                Add(equipable);
            }
        }
        if(_equipables.Count > 0) Equip(0);
    }
}
