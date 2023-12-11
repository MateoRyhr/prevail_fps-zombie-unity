using UnityEngine;

public class EnemyInstancesPerRound : MonoBehaviour, IGameObject
{
    [SerializeField] private IntVariable _currentRound;

    [SerializeField] private GameObject[] _easyEnemies;
    [SerializeField] private GameObject[] _mediumEnemies;
    [SerializeField] private GameObject[] _hardEnemies;

    // [SerializeField] private int _easyRounds;
    [SerializeField] private int _mediumRoundsStart;
    [SerializeField] private int _hardRoundsStart;

    public GameObject GameObject { get => _enemyToRespawn; set => _enemyToRespawn = value; }

    private GameObject _enemyToRespawn;

    public void SetRandomEnemy()
    {
        GameObject[] enemies = 
            {
                _easyEnemies[Random.Range(0,_easyEnemies.Length)],
                _mediumEnemies[Random.Range(0,_mediumEnemies.Length)],
                _hardEnemies[Random.Range(0,_hardEnemies.Length)]
            };
        _enemyToRespawn = enemies[Random.Range(0,enemies.Length)];
    }

    public void SetEasyEnemy()  => _enemyToRespawn = _easyEnemies[Random.Range(0,_easyEnemies.Length)];
    public void SetMediumEnemy()  => _enemyToRespawn = _mediumEnemies[Random.Range(0,_mediumEnemies.Length)];
    public void SetHardEnemy() => _enemyToRespawn = _hardEnemies[Random.Range(0,_hardEnemies.Length)];

    public void SetEnemyToRespawn()
    {
        //Easy
        if(_currentRound.Value < _mediumRoundsStart)
        {
            SetEasyEnemy();
            return;
        }
        //Medium
        if(_currentRound.Value < _hardRoundsStart)
        {
            if(Random.Range(0f,1f) < 0.66f)
                SetMediumEnemy();
            else
                SetEasyEnemy();
        }
        //Hard
        else
        {
            if(Random.Range(0f,1f) < 0.5f)
                SetHardEnemy();
            else
                if(Random.Range(0f,1f) < 0.5f)
                    SetMediumEnemy();
                else
                    SetEasyEnemy();
        }
    }
}
