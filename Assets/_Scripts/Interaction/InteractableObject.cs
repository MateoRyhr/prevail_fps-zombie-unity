using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class InteractableObject : MonoBehaviour, IGameObject
{
    public InteractionType InteractionType { get => _interactionType; }
    [SerializeField] private InteractionType _interactionType;
    
    public string Message { get => _message; } 
    [SerializeField] private string _message;

    public UnityEvent Interaction;

    public GameObject GameObject { get => _interactor; set => _interactor = value; }
    private GameObject _interactor;

    public void Interact(GameObject interactor){
        _interactor = interactor;
        Interaction?.Invoke();
    }
}

public enum InteractionType
{
    Action,
    RepairWindow,
    BuyWeapon,
    RemoveObject
}