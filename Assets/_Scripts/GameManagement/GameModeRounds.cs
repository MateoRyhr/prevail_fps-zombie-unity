using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameModeRounds : GameMode
{
    [SerializeField] private float _timeBetweenRounds = 10f;
    [SerializeField] private IntVariable _currentRound;
    // private int _currentRound;

    public UnityEvent OnNewRoundStart;
    public UnityEvent OnEndRound;

    public override void StartGameMode()
    {
        SetCurrentRound(0);
        StartNewRound();
        OnStartGame?.Invoke();
    }

    public override void EndGameMode()
    {
        OnEndGame?.Invoke();
    }

    public void StartNewRound()
    {
        SetToNextRound();
        this.Invoke(() => OnNewRoundStart?.Invoke(),_timeBetweenRounds);
    }

    public void EndRound(bool startOtherRound)
    {
        OnEndRound?.Invoke();

        if(startOtherRound)
            StartNewRound();
            // this.Invoke(() => StartNewRound(),_timeBetweenRounds);
    }

    public void SetCurrentRound(int round) => _currentRound.Value = round;
    public void SetToNextRound() => _currentRound.Value++;
}
