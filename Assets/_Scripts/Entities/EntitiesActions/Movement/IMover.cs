using UnityEngine;

public interface IMover
{
    public IMovement Movement { get; }
    public Vector3 Move(Vector3 direction, float timeLapsed);
}