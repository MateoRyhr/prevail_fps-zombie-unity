using UnityEngine;
using UnityEngine.Events;

public class Equipable : MonoBehaviour
{
    [Header("Settings")]
    public EquipableData EquipableData;
    [Tooltip("Transform when is equipped")]
    [SerializeField] private Transform _transformOnEquipping;
    [Tooltip("Transform when is unequipped")]
    [SerializeField] private Transform _transformOnUnequipping;
    [SerializeField] private GameObject _equipableModel;
    public float TimeEquipping => _timeEquipping;
    [SerializeField] private float _timeEquipping;
    public float TimeUnequipping => _timeUnequipping;
    [SerializeField] private float _timeUnequipping;
    [SerializeField] private float _timeToShow;
    [SerializeField] private float _timeToHide;

    public bool Equipped { get; set; }

    public UnityEvent OnEquippingStart;
    public UnityEvent OnShow;
    public UnityEvent OnEquippingEnd;
    public UnityEvent OnUnequippingStart;
    public UnityEvent OnHide;
    public UnityEvent OnUnequippingEnd;

    public void Equip(Transform parentOnEquipping)
    {
        SetInParent(parentOnEquipping,_transformOnEquipping);
        Equipped = true;
        OnEquippingStart?.Invoke();
        this.InvokeScaledDeltaTime(() => 
        {
            OnEquippingEnd?.Invoke();
        },_timeEquipping);
        this.InvokeScaledDeltaTime(() => 
        {
            _equipableModel.SetActive(true);
            OnShow?.Invoke();
        },_timeToShow);
    }

    public void Unequip(Transform parentOnUnequipping)
    {
        OnUnequippingStart?.Invoke();
        this.InvokeScaledDeltaTime(() => 
        {
            Equipped = false;
            OnUnequippingEnd?.Invoke();
        },_timeUnequipping);
        this.InvokeScaledDeltaTime(() => 
        {
            SetInParent(parentOnUnequipping,_transformOnUnequipping);
            _equipableModel.SetActive(false);
            OnHide?.Invoke();
        },_timeToHide);
    }

    void SetInParent(Transform parent, Transform transformOnParent)
    {
        transform.SetParent(parent);
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0,0,0);
        transform.localPosition = transformOnParent.position;
        transform.localRotation = transformOnParent.rotation;
    }
}