using UnityEngine;

public class Destroy : MonoBehaviour
{
    public void DestroyItself()
    {
        Destroy(gameObject);
    }

    public void DestroyItself(float delay)
    {
        Destroy(gameObject,delay);
    }

    public void DestroyOther(GameObject other)
    {
        Destroy(other);
    }
}
