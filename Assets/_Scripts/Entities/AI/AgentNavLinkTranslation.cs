using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentNavLinkTranslation : MonoBehaviour
{
    [SerializeField] private Collider _agentColliderToTriggerTeleport;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject[] desactiveOnTranslation;
    [SerializeField] private MonoEvent[] _events;

    public void StartTranslation(Vector3 newPosition, int eventType)
    {
        // Debug.Log($"Started");
        Active(false);
        DesactivePhysics();
        //Animation
        _events[eventType].UnityEvent?.Invoke();

        StartCoroutine(Translate(newPosition,_events[eventType].EventTime));

        this.Invoke(() => {
            ActivePhysics();
            Active(true);
        },_events[eventType].EventTime);
    }

    IEnumerator Translate(Vector3 targetPosition,float translationTime)
    {
        Vector3 startPosition = _rigidbody.position;
        float timeElapsed = 0f;

        while(timeElapsed < translationTime)
        {
            Vector3 nextPosition = Vector3.Lerp(startPosition,targetPosition,timeElapsed/translationTime);
            _rigidbody.position = nextPosition;
            timeElapsed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        _rigidbody.position = targetPosition;
    }

    public void StartTeleport(Vector3 newPosition, int eventType)
    {
        Active(false);
        DesactivePhysics();

        //Animation
        _events[eventType].UnityEvent?.Invoke();

        this.Invoke(() => {
            Teleport(newPosition);
        },_events[eventType].EventTime);
    }

    void Teleport(Vector3 newPosition)
    {
        _rigidbody.position = newPosition;
        this.Invoke(() => {
            ActivePhysics();
            Active(true);
        },Time.fixedDeltaTime);
        // Debug.Log($"Translated");
    }

    void Active(bool state)
    {
        foreach (var gObject in desactiveOnTranslation)
        {
            gObject.SetActive(state);
        }
    }

    void ActivePhysics()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = false;
        _agentColliderToTriggerTeleport.enabled = true;
        _agent.enabled = true;
        _rigidbody.detectCollisions = true;
    }

    void DesactivePhysics()
    {
        _agentColliderToTriggerTeleport.enabled = false;
        _rigidbody.velocity = Vector3.zero;
        _agent.enabled = false;
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = true;
        _rigidbody.detectCollisions = false;
    }
}


