using UnityEngine;
using UnityEngine.Events;

public class EnemyRespawnerPerRounds : MonoBehaviour
{
    [SerializeField] private EnemyRespawner _respawner;
    [SerializeField] private int[] _enemiesPerRound;
    [SerializeField] private int[] _maxEnemiesAtSameTimePerRound;
    [SerializeField] private IntVariable _currentRound;

    private int _enemiesLeftToRespawn;
    private int _enemiesLeft;
    private int _currentEnemies;

    public UnityEvent OnNoEnemiesLeft;

    public void RespawnEnemies(float delay)
    {
        this.Invoke(() => 
        {
            int amountToRespawn = AmountToRespawn();
            _enemiesLeftToRespawn -= amountToRespawn;
            _currentEnemies += amountToRespawn;
            _respawner.RespawnEnemies(amountToRespawn);
        },delay);
    }

    public void SetEnemiesOfRound()
    {
        int enemiesInThisRound =
            _currentRound.Value - 1 < _enemiesPerRound.Length
            ? _enemiesPerRound[_currentRound.Value - 1]
            : _enemiesPerRound[_enemiesPerRound.Length-1];
        
        _enemiesLeftToRespawn = enemiesInThisRound;
        _enemiesLeft = enemiesInThisRound;
    }

    int AmountToRespawn()
    {
        int maxEnemies =
            _currentRound.Value - 1 < _maxEnemiesAtSameTimePerRound.Length
            ? _maxEnemiesAtSameTimePerRound[_currentRound.Value]
            : _maxEnemiesAtSameTimePerRound[_maxEnemiesAtSameTimePerRound.Length-1];

        return Mathf.Clamp(_enemiesLeftToRespawn,0,maxEnemies - _currentEnemies);
    }

    public void EnemyDie()
    {
        _currentEnemies--;
        _enemiesLeft--;
        if(_enemiesLeft == 0)
            OnNoEnemiesLeft?.Invoke();
    }
}
