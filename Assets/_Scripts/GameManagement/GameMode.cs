using UnityEngine;
using UnityEngine.Events;

public abstract class GameMode : MonoBehaviour
{
    public UnityEvent OnStartGame;
    public UnityEvent OnEndGame;

    public abstract void StartGameMode();
    public abstract void EndGameMode();
}
