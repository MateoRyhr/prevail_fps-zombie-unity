using UnityEngine;

public class PlayerTotalScore : MonoBehaviour, IAmount
{
    [SerializeField] PlayerScore _playerScore;

    public Amount Amount { get => _playerScore.TotalScore; }
}