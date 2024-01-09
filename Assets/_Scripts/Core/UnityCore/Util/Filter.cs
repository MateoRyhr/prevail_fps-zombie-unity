using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Filter
{
    public static Collider[] GetUniqueChildrenOfRoot(Collider[] colliders)
    {
        List<Transform> roots = new List<Transform>();
        List<Collider> collidersList = colliders.ToList();
        foreach (Collider collider in colliders)
        {
            Transform root = ColliderUtil.GetColliderRoot(collider).transform;
            if(!roots.Contains(root)) roots.Add(root);
            else collidersList.Remove(collider);
        }
        return collidersList.ToArray();
    }

    public static List<Collider> GetUniqueChildrenOfRoot(List<Collider> colliders)
    {
        List<Transform> roots = new List<Transform>();
        List<Collider> collidersList = colliders.ToList();
        foreach (Collider collider in colliders)
        {
            Transform root = ColliderUtil.GetColliderRoot(collider).transform;
            if(!roots.Contains(root)) roots.Add(root);
            else collidersList.Remove(collider);
        }
        return collidersList;
    }


}
