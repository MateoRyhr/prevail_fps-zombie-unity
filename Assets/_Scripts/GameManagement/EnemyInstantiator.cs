using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInstantiator", menuName = "EnemyManagement/EnemyInstantiator")]
public class EnemyInstantiator : ScriptableObject
{
    [SerializeField] private GameObject _enemyPrefab;
    // [SerializeField] private int _maxEnemies = 20;
    // [SerializeField] private int[] _maxEnemiesPerRound = {4,4,6,8,10,12,16,20};

    // public UnityEvent OnAllEnemiesDead;

    // private int _enemiesLeft;
    // private int _currentEnemies;
    // private List<GameObject> _enemiesPool;

    private void OnEnable()
    {
        // _enemiesPool = new List<GameObject>();
        // Reset();
    }

    public GameObject CreateEnemy(Vector3 position)
    {
        // _currentEnemies++;
        return Instantiate(
            _enemyPrefab,
            position,
            Quaternion.identity
        );
        // return enemy;
    }

    // public GameObject GetEnemy()
    // {
    //     if(_currentEnemies < _maxEnemies)
    //     {
    //         _enemiesPool.Add(CreateEnemy());
    //         _currentEnemies++;
    //     }
    //     else
    //     {
    //         GameObject enemy = _enemiesPool[0];
    //         _enemiesPool.Remove(enemy);
    //         _enemiesPool.Add(enemy);
    //     }
    //     return _enemiesPool[_enemiesPool.Count-1];
    // }

    // public void Reset()
    // {
    //     _enemiesLeft = 0;
    //     _currentEnemies  = 0;
    //     _maxEnemies = 0;
    // }

    // public void SetMaxEnemies(int max) => _maxEnemies = max;
}
