using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentGameState;
    private GameMode _currentGameMode;

    public UnityEvent OnGame;
    public UnityEvent OnPause;
    public UnityEvent OnMenu;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void SetCurrentGameMode(GameMode gameMode) => _currentGameMode = gameMode;

    public void StartGame()
    {
        _currentGameMode.StartGameMode();
    }

    public void UpdateState(string newState)
    {
        switch (newState)
        {
            case "InMenu":
                CurrentGameState = GameState.InMenu;
                OnMenu?.Invoke();
                break;
            case "InGame":
                CurrentGameState = GameState.InGame;
                OnGame?.Invoke();
                break;
            case "InPauseMenu":
                CurrentGameState = GameState.InPauseMenu;
                OnPause?.Invoke();
                break;
            default:
                Debug.Log("The string parametter must be the name of a type GameState");
                break;
        }
    }
}

public enum GameState
{
    InMenu,
    InGame,
    InPauseMenu
}