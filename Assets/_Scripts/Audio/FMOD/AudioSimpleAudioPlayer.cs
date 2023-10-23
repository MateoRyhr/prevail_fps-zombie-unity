using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioSimpleAudioPlayer : MonoBehaviour
{
    [SerializeField] private Transform _audioTransform;
    [Range(0f,1f)]
    [SerializeField] private float Volume = 1f;

    private void Awake()
    {
        if(!_audioTransform) _audioTransform = gameObject.transform;
    }

    public void PlayAudioFast(Sound sound)
    {
        RuntimeManager.PlayOneShot(sound.soundEvent,_audioTransform.position);
    }

    public void PlayAudio(Sound sound)
    {
        EventInstance soundInstance = RuntimeManager.CreateInstance(sound.soundEvent);
        soundInstance.setVolume(Volume);
        soundInstance.set3DAttributes(RuntimeUtils.To3DAttributes(new Vector3(0f,0f,0f)));
        soundInstance.start();
        soundInstance.release();
    }

    public void PlayAudioAttached(Sound sound)
    {
        EventInstance soundInstance = RuntimeManager.CreateInstance(sound.soundEvent);
        soundInstance.setVolume(Volume);
        soundInstance.set3DAttributes(RuntimeUtils.To3DAttributes(_audioTransform.position));
        soundInstance.start();
        soundInstance.release();
    }
}
