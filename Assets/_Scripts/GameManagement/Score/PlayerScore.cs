using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour, IAmount
{
    [SerializeField] private float _initialScore;
    [SerializeField] private float _maxScore;

    public Amount Score;
    public Amount Amount { get => Score; set => Score = value; }

    public UnityEvent OnScoreModified;
    public UnityEvent OnAddScore;
    public UnityEvent OnRestScore;

    private void Awake()
    {
        Score = new Amount(_initialScore,_maxScore);
        Score.OnAmountModified += OnScoreModified.Invoke;
        Score.OnAddToTheAmount += OnAddScore.Invoke;
        Score.OnSubstractToTheAmount += OnRestScore.Invoke;
    }

    public void Add(float amount) => Score.Add(amount);
}
