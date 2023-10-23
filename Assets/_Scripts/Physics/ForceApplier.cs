using UnityEngine;

public class ForceApplier : MonoBehaviour
{
    public FloatVariable ForceAmount;
    public float MaxVariation;

    public void ApplyForceAtPoint(GameObject other, Vector3 contactPoint, float delay,bool addForceVariation)
    {
        if(!other) return;
        ForceReceiver forceReceiver = other.GetComponent<ForceReceiver>();
        if(forceReceiver)
        {
            Vector3 forceDirection = (contactPoint - transform.position).normalized;
            if(addForceVariation) forceDirection = AddVariation(forceDirection);
            Vector3 force = forceDirection * ForceAmount.Value;
            forceReceiver.ReceiveForceAtPoint(force,contactPoint,delay);
        }
    }

    public void ApplyForceAtPoint(Collision collision,float delay,bool addForceVariation)
    {
        if(!collision.collider) return;
        ForceReceiver forceReceiver = collision.gameObject.GetComponent<ForceReceiver>();
        if(forceReceiver)
        {
            Vector3 contactPoint = collision.collider.ClosestPoint(transform.position);
            // Vector3 contactPoint = collision.contacts[0].point;
            Vector3 forceDirection = (contactPoint - transform.position).normalized;
            if(addForceVariation) forceDirection = AddVariation(forceDirection);
            Vector3 force = forceDirection * ForceAmount.Value;
            forceReceiver.ReceiveForceAtPoint(force,contactPoint,delay);
        }
    }

    public void ApplyForceAtPoint(Collision collision, Vector3 forceDirection, float delay, bool addForceVariation)
    {
        if(!collision.collider) return;
        ForceReceiver forceReceiver = collision.gameObject.GetComponent<ForceReceiver>();
        if(forceReceiver)
        {
            Vector3 contactPoint = collision.collider.ClosestPoint(transform.position);
            // Vector3 contactPoint = collision.contacts[0].point;
            if(addForceVariation) forceDirection = AddVariation(forceDirection);
            Vector3 force = forceDirection * ForceAmount.Value;
            forceReceiver.ReceiveForceAtPoint(force,contactPoint,delay);
        }    
    }

    public void ApplyForce(Collision collision, Vector3 forceDirection, float delay, bool addForceVariation)
    {
        if(!collision.collider) return;
        ForceReceiver forceReceiver = collision.gameObject.GetComponent<ForceReceiver>();
        if(forceReceiver)
        {
            if(addForceVariation) forceDirection = AddVariation(forceDirection);
            Vector3 force = forceDirection * ForceAmount.Value;
            forceReceiver.ReceiveForce(force,delay);
        }  
    }

    public void ApplyForce(Collision collision, float delay, bool addForceVariation)
    {
        if(!collision.collider) return;
        ForceReceiver forceReceiver = collision.gameObject.GetComponent<ForceReceiver>();
        if(forceReceiver)
        {
            Vector3 forceDirection = (collision.contacts[0].point - transform.position).normalized;
            if(addForceVariation) forceDirection = AddVariation(forceDirection);
            Vector3 force = forceDirection * ForceAmount.Value;
            forceReceiver.ReceiveForce(force,delay);
        }  
    }

    Vector3 AddVariation(Vector3 force)
    {
        return new Vector3(
            force.x + Random.Range(-MaxVariation,MaxVariation),
            force.y + Random.Range(-MaxVariation,MaxVariation),
            force.z + Random.Range(-MaxVariation,MaxVariation)
        );
    }
}
