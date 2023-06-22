using UnityEngine;

public abstract class RotationInAxisTransporter : MonoBehaviour
{
    [SerializeField] protected Transform _source;
    [SerializeField] protected Transform _receiver;
}
