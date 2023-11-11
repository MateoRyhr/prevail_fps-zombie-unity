using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioSimpleAudioPlayer : MonoBehaviour, IFloat
{
    [SerializeField] private Transform _audioTransform;
    // [Range(0f,1f)]
    [SerializeField] private float _volume = 1f;

    public float Value { get => _currentSoundLength; set => throw new System.NotImplementedException(); }

    private float _currentSoundLength;

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
        EventInstance soundInstance = CreateSound(sound);
        soundInstance.setVolume(_volume);
        soundInstance.set3DAttributes(RuntimeUtils.To3DAttributes(new Vector3(0f,0f,0f)));
        soundInstance.start();
        soundInstance.release();
    }

    public void PlayAudioAttached(Sound sound)
    {
        EventInstance soundInstance = CreateSound(sound);
        soundInstance.setVolume(_volume);
        soundInstance.set3DAttributes(RuntimeUtils.To3DAttributes(_audioTransform.position));
        soundInstance.start();
        soundInstance.release();
    }

    EventInstance CreateSound(Sound sound)
    {
        EventInstance soundInstance = RuntimeManager.CreateInstance(sound.soundEvent);

        soundInstance.getDescription(out EventDescription eventDescription);
        eventDescription.getLength(out int miliseconds);
        _currentSoundLength = ((float)miliseconds);
        return soundInstance;
    }
}
