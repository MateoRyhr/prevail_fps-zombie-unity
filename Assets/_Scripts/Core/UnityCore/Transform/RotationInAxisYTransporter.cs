using UnityEngine;

public class RotationInAxisYTransporter : RotationInAxisTransporter
{
    private void FixedUpdate() => 
        _receiver.localRotation = 
            Quaternion.Euler(
                new Vector3(
                    _receiver.localRotation.x,
                    _source.localRotation.eulerAngles.y,
                    _receiver.localRotation.z
                )
            );
}
