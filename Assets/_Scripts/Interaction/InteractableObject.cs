using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class InteractableObject : MonoBehaviour, ICollider
{
    [SerializeField] private InteractionType _interactionType;

    public UnityEvent Interaction;

    public Collider Collider => _interactorCollider;
    private Collider _interactorCollider;

    public void Interact(Collider interactorCollider){
        _interactorCollider = interactorCollider;
        Interaction?.Invoke();
    }
}

public enum InteractionType
{
    Action,
    RepairWindow,
    BuyWeapon
}

public class InteractByTrigger
{
    private void OnTriggerEnter(Collider other)
    {
        // if(other.)
    }
}
