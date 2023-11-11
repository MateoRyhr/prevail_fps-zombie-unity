using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioParametterAudioPlayer : MonoBehaviour
{
    [Tooltip("Object that provides the value of the parametter.")]
    [SerializeField] private GameObject _typeProvider;
    [SerializeField] private Transform _audioTransform;
    
    private ITypeProvider _parametter;

    private void Awake()
    {
        _parametter = _typeProvider.GetComponent<ITypeProvider>();
    }

    public void PlayAudio(Sound sound)
    {
        EventInstance soundInstance = GetSoundWithParametter(sound);
        soundInstance.set3DAttributes(RuntimeUtils.To3DAttributes(new Vector3(0f,0f,0f)));
        soundInstance.start();
        soundInstance.release();
    }

    public void PlayAudioAttached(Sound sound)
    {
        EventInstance soundInstance = GetSoundWithParametter(sound);
        soundInstance.set3DAttributes(RuntimeUtils.To3DAttributes(_audioTransform.position));
        soundInstance.start();
        soundInstance.release();
    }

    EventInstance GetSoundWithParametter(Sound sound)
    {
        EventInstance soundInstance = RuntimeManager.CreateInstance(sound.soundEvent);
        soundInstance.setParameterByNameWithLabel(_parametter.TypeName,_parametter.Type);
        return soundInstance;
    }

    // float GetSoundLength(EventInstance soundInstance)
    // {
    //     EventDescription eventDescription;
    //     soundInstance.getDescription(out eventDescription);
    //     int lengthInMs;
    //     eventDescription.getLength(out lengthInMs);
    //     return (float)lengthInMs / 1000f;
    // }
}
