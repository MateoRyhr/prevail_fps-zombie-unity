using UnityEngine;

public abstract class SurfaceGetter : MonoBehaviour, ITypeProvider
{
    public Surface Surface { get; set; }
    public string TypeName => Surface.GetType().Name;
    public string Type => Surface.Type;
    public int Value => Surface.Value;
}
