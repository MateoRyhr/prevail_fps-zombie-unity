using UnityEngine;
using UnityEngine.Events;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public UnityEvent OnPauseGame;
    public UnityEvent OnResumeGame;

    public void PauseOrResume()
    {
        if(gameManager.CurrentGameState == GameState.InGame)
        {
            OnPauseGame?.Invoke();
            return;
        }
        if(gameManager.CurrentGameState == GameState.InPauseMenu)
        {
            OnResumeGame?.Invoke();
            return;
        }
    }
}
