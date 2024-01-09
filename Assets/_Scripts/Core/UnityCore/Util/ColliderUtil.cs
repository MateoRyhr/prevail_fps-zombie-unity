using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColliderUtil
{
    public static Collider GetColliderRoot(Collider collider)
    {
        Collider[] collidersParents = collider.GetComponentsInParent<Collider>();
        if(collidersParents.Length > 0) return collidersParents[collidersParents.Length-1];
        else return collider;
    }

    public static bool CheckDirectContact(Collider from, Collider to, bool parentColliderIsCollider)
    {
        Vector3 direction = (to.bounds.center - from.bounds.center).normalized;
        Physics.Raycast(from.bounds.center,direction,out RaycastHit hit,Mathf.Infinity);
        if(!hit.collider) return false;
        if(hit.collider == to) return true;
        else
            if(parentColliderIsCollider && (GetColliderRoot(to) == GetColliderRoot(hit.collider)))
                return true;
        return false;
    }
}
