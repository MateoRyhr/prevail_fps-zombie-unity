using UnityEngine;

public class ParticlesFXInstantiator : MonoBehaviour
{
    [SerializeField] private Transform _fxParent;
    // [SerializeField] private GameObject fxPrefab;
    [SerializeField] private ParticleSystem _fxParticleSystem;
    [SerializeField] private float _fxDuration;

    private void Awake()
    {
        if(!_fxParent) _fxParent = transform;
    }

    public void PlayEffect(){
        ParticleSystem fx = Instantiate(_fxParticleSystem,_fxParent.position,_fxParticleSystem.transform.rotation,null);
        if(!_fxParticleSystem.main.playOnAwake) fx.Play(true);
        Destroy(fx.gameObject,_fxDuration);
    }

    public void PlayEffectTransformAsParent(){
        ParticleSystem fx = Instantiate(_fxParticleSystem,_fxParent.position,_fxParent.transform.rotation,_fxParent);
        if(!_fxParticleSystem.main.playOnAwake) fx.Play(true);
        Destroy(fx.gameObject,_fxDuration);
    }
}
