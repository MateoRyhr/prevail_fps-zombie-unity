using UnityEngine;

public class RotationInAxisXTransporter : RotationInAxisTransporter
{
    private void FixedUpdate() => 
        _receiver.localRotation = 
            Quaternion.Euler(
                new Vector3(
                    _source.localRotation.eulerAngles.x,
                    _receiver.localRotation.y,
                    _receiver.localRotation.z
                )
            );
}
