using UnityEngine;
using FMODUnity;

[CreateAssetMenu(fileName = "NewSound", menuName = "Audio/FMOD Sound")]
public class Sound : ScriptableObject
{
    public EventReference soundEvent;
}
