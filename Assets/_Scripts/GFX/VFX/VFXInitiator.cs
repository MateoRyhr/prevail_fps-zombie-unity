using UnityEngine;

public class VFXInitiator : MonoBehaviour
{
    [SerializeField] private DecalOnCollision[] _decals;
    [SerializeField] private ParticlesOnCollision[] _particles;

    public void InitVFX()
    {
        foreach (var decal in _decals)
        {
            decal.Init();
        }
        foreach (var particle in _particles)
        {
            particle.Init();
        }
    }
}
