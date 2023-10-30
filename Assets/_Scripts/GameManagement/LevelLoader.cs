using UnityEngine;
using UnityEngine.Events;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private float _timeAfterLoadScene = 0f;
    [SerializeField] private SceneLoader _sceneLoader;

    public UnityEvent OnStartLoadScene;
    public UnityEvent OnSceneLoaded;
    
    private void Awake()
    {
        OnSceneLoaded.AddListener(() => {
            _sceneLoader.OnSceneLoaded.RemoveListener(SceneLoadedAfterTime);
        });  
    }

    public void LoadScene(string sceneName){
        OnStartLoadScene?.Invoke();
        _sceneLoader.OnSceneLoaded.AddListener(SceneLoadedAfterTime);
        _sceneLoader.LoadScene(sceneName);
    }

    void SceneLoadedAfterTime()
    {
        this.Invoke(() =>  OnSceneLoaded?.Invoke(),_timeAfterLoadScene);
    }
}
