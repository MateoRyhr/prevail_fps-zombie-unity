using UnityEngine;
using UnityEngine.Events;

public class InteractorByTrigger : MonoBehaviour
{
    [SerializeField] private Interactor _interactor;
    public InteractionType InteractionType { get => _interactionType; }
    [SerializeField] private InteractionType _interactionType;

    public string Message { get; private set; }
    [Tooltip("Start point to check with raycast that is in front and not behind something")]
    [SerializeField] private Transform _isInFrontCheckStart;

    public UnityEvent OnInteractableEnter;
    public UnityEvent OnInteractableExit;

    //If enter trigger is called is because is a InteractableObject, set that using 2 layers, and make them only collides with each other
    private void OnTriggerEnter(Collider other)
    {
        if(!CheckIsInFront(other)) return;
        InteractableObject interactable = other.GetComponent<InteractableObject>();
        if(interactable.InteractionType != _interactionType) return;
        if(_interactor.Interactable == null)
            _interactor.Interactable = interactable;
        OnInteractableEnter.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if(!CheckIsInFront(other)) return;
        InteractableObject interactable = other.GetComponent<InteractableObject>();
        if(interactable.InteractionType != _interactionType) return;
        if(_interactor.Interactable == null)
            _interactor.Interactable = interactable;
        OnInteractableEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnInteractableExit?.Invoke();
    }

    bool CheckIsInFront(Collider interactable)
    {
        // Vector3 direction = transform.forward;
        Vector3 direction = interactable.bounds.center - _isInFrontCheckStart.position;
        RaycastHit hit;
        Physics.Raycast(_isInFrontCheckStart.position,direction,out hit);
        // Debug.Log($"{hit.collider.gameObject.name}");
        if(hit.collider.gameObject.name == interactable.gameObject.name) return true;
        else return false;
    }

}
