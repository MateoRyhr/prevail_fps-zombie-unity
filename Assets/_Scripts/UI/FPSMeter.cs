using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSMeter : MonoBehaviour
{
    [SerializeField] private GameObject _objectToActiveDesactive;
    [SerializeField] TextMeshProUGUI _fpsText;
    bool enable = false;

    public void Enable(){
        _objectToActiveDesactive.SetActive(true);
        enable = true;
        _fpsText.gameObject.SetActive(true);
        StartCoroutine(UpdateFrameMeter());
    }

    public void Disable(){
        _objectToActiveDesactive.SetActive(false);
        enable = false;
        _fpsText.gameObject.SetActive(false);
        StopCoroutine(UpdateFrameMeter());
    }

    public void SwitchStatus(){
        if(enable)
            Disable();
        else
            Enable();
    }

    IEnumerator UpdateFrameMeter(){
        yield return new WaitForSecondsRealtime(1f);
        _fpsText.text = ((int)(1f/Time.deltaTime)).ToString();
        if(enable) StartCoroutine(UpdateFrameMeter());
    }
}
