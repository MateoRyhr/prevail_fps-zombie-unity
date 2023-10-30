using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _progressBar;
    
    public UnityEvent OnSceneLoaded;
    public UnityEvent OnUnloadScene;

    const int GameSceneBuildIndex = 1;

    public void LoadScene(string sceneName){
        StartCoroutine("Loading",sceneName);
    }

    public IEnumerator Loading(string sceneName){
        // _loadingScreen.gameObject.SetActive(true);
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        while(!scene.isDone){
            _progressBar.value = scene.progress*110;
            yield return null;
        }
        OnSceneLoaded?.Invoke();
        // _loadingScreen.gameObject.SetActive(false);
    }

    public IEnumerator UnloadScene(){
        AsyncOperation scene = SceneManager.LoadSceneAsync("EmptyScene",LoadSceneMode.Single);
        while(!scene.isDone){
            yield return null;
        }
        OnUnloadScene?.Invoke();
        // GameManager.Instance.UpdateState("InMenu");
    }

    public void ExitScene(float delay){
        this.Invoke(() => {
            StartCoroutine(UnloadScene());
        },delay);
    }
}
