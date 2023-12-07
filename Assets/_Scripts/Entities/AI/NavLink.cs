using UnityEngine;

public class NavLink : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private string _agentColliderTag;
    [Tooltip("A number that identifies what type of translation will execute (jump, fall, etc)")]
    [SerializeField] private int translationN;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(_agentColliderTag))
            other.GetComponent<AgentNavLinkTranslation>().StartTranslation(GetDistantPoint(other),translationN);
    }

    void Teleport(Collider agent)
    {
        agent.transform.Translate(GetTranslationToDistantPoint(agent));
    }

    //Returns the distant point to the agent
    Vector3 GetTranslationToDistantPoint(Collider agent)
    {
        float distanceToA = Vector3.Distance(agent.transform.position,_pointA.position);
        float distanceToB = Vector3.Distance(agent.transform.position,_pointB.position);
        return distanceToA > distanceToB
            ? (_pointA.position - agent.transform.position) * distanceToA
            : (_pointB.position - agent.transform.position) * distanceToB;
    }

    Vector3 GetDistantPoint(Collider agent)
    {
        float distanceToA = Vector3.Distance(agent.transform.position,_pointA.position);
        float distanceToB = Vector3.Distance(agent.transform.position,_pointB.position);
        return distanceToA > distanceToB ? _pointA.position : _pointB.position;
    }
}
