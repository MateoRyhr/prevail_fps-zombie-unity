using UnityEngine;

public class Surface : MonoBehaviour, ITypeProvider
{
    [SerializeField] private SurfaceType _surfaceType;
    public SurfaceType SurfaceType { get => _surfaceType; }

    public string TypeName => this.GetType().Name;
    public string Type => _surfaceType.ToString();
    public int Value => (int)_surfaceType;

    public Surface(SurfaceType type)
    {
        _surfaceType = type;
    }
}

public enum SurfaceType
{
    Flesh,
    Concrete,
    Wood,
    Metal,
    Glass,
    Default
}