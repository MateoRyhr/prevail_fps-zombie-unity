using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateSetter : MonoBehaviour
{
    [SerializeField] IntVariable TargetFrameRate;

    private void Awake() {
        Application.targetFrameRate = TargetFrameRate.Value;
    }
}
