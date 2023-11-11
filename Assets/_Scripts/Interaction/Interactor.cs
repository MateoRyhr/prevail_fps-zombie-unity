using UnityEngine;

public class Interactor : MonoBehaviour
{
    public InteractableObject Interactable { get => _interactable; set => _interactable = value; }
    private InteractableObject _interactable;

    public void Interact()
    {
        if(_interactable != null)
        {
            _interactable.Interact(gameObject);
            _interactable = null;
        }
    }
}
