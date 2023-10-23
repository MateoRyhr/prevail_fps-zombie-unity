using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ParticlesFXBySurface : MonoBehaviour
{
    [SerializeField] private ParticlesOnCollision[] _particlesBySurface;

    private SurfaceGetter _surfaceGetter;
    private ICollision _collisionGetter;

    private void Awake()
    {
        _surfaceGetter = GetComponent<SurfaceGetter>();
        _collisionGetter = GetComponent<ICollision>();
    }

    public void PlayParticles(bool surfaceAsParent)
    {
        if(_surfaceGetter.Surface != null && _particlesBySurface.Length > SurfaceType())
            _particlesBySurface[SurfaceType()].PlayParticles(_collisionGetter.Collision,surfaceAsParent);
    }

    int SurfaceType() => (int)_surfaceGetter.Surface.SurfaceType;
}
