using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour, IAmount
{
    [SerializeField] private float _initialScore;
    [SerializeField] private float _maxScore;

    public Amount Score;
    public Amount Amount { get => Score; set => Score = value; }

    public UnityEvent OnAddScore;

    private void Awake()
    {
        Score = new Amount(_initialScore,_maxScore);
        Score.OnAddToTheAmount += OnAddScore.Invoke;
    }

    public void Add(float amount) => Score.Add(amount);
}
