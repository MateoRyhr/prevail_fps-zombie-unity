using UnityEngine;
using UnityEngine.Animations.Rigging;

public class EntityRigConstraints : MonoBehaviour
{
    [SerializeField] public GameObject[] Rigs;

    public void DisableAllRigs()
    {
        foreach (GameObject rig in Rigs)
        {
            rig.GetComponent<Rig>().weight = 0f;
        }
    }

    public void EnableConstraint(GameObject constraint)
    {
        constraint.GetComponent<Rig>().weight = 1f;
    }

    public void DisableConstraint(GameObject constraint)
    {
        constraint.GetComponent<Rig>().weight = 0f;
    }

    public void EnableConstraints(GameObject[] constraints)
    {
        foreach (GameObject constraint in constraints)
        {
            constraint.GetComponent<Rig>().weight = 1f;
        }
    }

    public void DisableConstraints(GameObject[] constraints)
    {
        foreach (GameObject constraint in constraints)
        {
            constraint.GetComponent<Rig>().weight = 0f;
        }
    }
}