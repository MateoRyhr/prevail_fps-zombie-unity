using UnityEngine;

public class RotationInAxisZTransporter : RotationInAxisTransporter
{
    private void FixedUpdate() => 
        _receiver.localRotation = 
            Quaternion.Euler(
                new Vector3(
                    _receiver.localRotation.x,
                    _receiver.localRotation.y,
                    _source.localRotation.eulerAngles.z
                )
            );
}
