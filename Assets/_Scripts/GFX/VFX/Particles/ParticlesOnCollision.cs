using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "ParticlesOnCollision", menuName = "Particles/ParticlesOnCollision")]
public class ParticlesOnCollision : ScriptableObject
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private int _maxAmount;

    private ObjectPool<ParticleSystem> _pool;

    public ParticleSystem InstantiateObject() => Instantiate(_particles);

    public void OnDestroyFromPool(ParticleSystem particles) => Destroy(particles.gameObject);

    void OnGetFromPool(ParticleSystem particles) => particles.gameObject.SetActive(true);

    public void OnReturnToPool(ParticleSystem particles)
    {
        particles.gameObject.SetActive(false);
    }

    public void PlayParticles(Collision collision, bool collisionAsParent) => InstantiateParticles(collision, collisionAsParent);

    void InstantiateParticles(Collision collision, bool collisionAsParent)
    {
        ParticleSystem particles = _pool.Get();
        SetParticlesPosition(particles,collision,collisionAsParent);
        particles.GetComponent<Actioner>().PerformAction(() => _pool.Release(particles),particles.main.duration);
    }

    void SetParticlesPosition(ParticleSystem particles, Collision collision,bool collisionAsParent)
    {
        Transform parent = collisionAsParent ? collision.transform : null;
        Vector3 position = collision.GetContact(0).point + collision.GetContact(0).normal * .01f;
        Quaternion rotation = Quaternion.LookRotation(collision.GetContact(0).normal);
        particles.transform.SetPositionAndRotation(position,rotation);
    }

    public void Init()
    {
        _pool = new ObjectPool<ParticleSystem>(InstantiateObject,OnGetFromPool,OnReturnToPool,OnDestroyFromPool,true,_maxAmount);
    }
}