using UnityEngine;

public class Logger : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] bool _showLog;

    public void Log(object message, Object sender)
    {
        if(_showLog)
            Debug.Log(message,sender);
    }
}