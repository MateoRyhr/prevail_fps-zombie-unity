using UnityEngine;

public class RagdollDeath : MonoBehaviour
{
    [SerializeField] int _ragdollLayer;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _functionalityObject;
    [SerializeField] GameObject[] _objectsToDesactivate;
    
    private Rigidbody[] _ragdollRigidbodies;

    private void Awake()
    {
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    public void ActiveRagdoll(){
        _animator.enabled = false;

        foreach (GameObject objectToDesactivate in _objectsToDesactivate)
        {
            objectToDesactivate.SetActive(false);
        }

        Component[] functionalityComponents = _functionalityObject.GetComponents<Component>();
        foreach (Component functionalityComponent in functionalityComponents)
        {
            if(!(functionalityComponent is Transform))
                Destroy(functionalityComponent);
        }

        Component[] animationComponents = _animator.GetComponents<Component>();
        foreach (Component animationComponent in animationComponents)
        {
            if(!(animationComponent is Transform) && !(animationComponent is Animator))
                Destroy(animationComponent);
        }

        // this.Invoke(() =>
        // {
        foreach (Rigidbody ragdollRigidbody in _ragdollRigidbodies){
            ragdollRigidbody.gameObject.layer = _ragdollLayer;
            ragdollRigidbody.isKinematic = false;
            ragdollRigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            ragdollRigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete; 
            ragdollRigidbody.useGravity = true;
        }
    //     },
    //     2f);
    }
}
