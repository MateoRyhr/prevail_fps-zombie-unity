using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "NewSound", menuName = "Audio/FMOD SoundWithTagParametter")]
public class SoundWithTagParametter : ScriptableObject
{
    public EventReference soundEvent;
    public string parametterName;
    public int parametterValue;
}
