using UnityEngine;
using System.Collections.Generic;

public class EnemyRespawner : MonoBehaviour
{
    [SerializeField] private EnemyInstantiator _enemyInstantiator;
    [SerializeField] private Transform[] _respawnPoints;
    [SerializeField] private Vector3Variable _playerPosition;
    [SerializeField] private float _timeBetweenRespawn;
    
    public void RespawnEnemies(int enemiesAmount)
    {
        Vector3[] respawnPoints = GetNClosestPoints(2,_playerPosition.Value);
        int enemiesPerRespawn = (int)(enemiesAmount / _respawnPoints.Length);
        int restOfEnemies = enemiesAmount % _respawnPoints.Length;
        foreach (var point in respawnPoints)
        {
            for (var i = 0; i < enemiesPerRespawn; i++)
            {
                this.Invoke(() => {
                    GameObject enemy = _enemyInstantiator.CreateEnemy(point);
                },_timeBetweenRespawn * i);
            }
        }

        if(restOfEnemies > 0)
            this.Invoke(() => {
                for (var i = 0; i < restOfEnemies; i++)
                {
                    GameObject enemy = _enemyInstantiator.CreateEnemy(respawnPoints[i]);
                }
            },_timeBetweenRespawn * enemiesPerRespawn);
    }

    Vector3[] GetNClosestPoints(int n, Vector3 playerPosition)
    {
        List<Vector3> closestPoints = new List<Vector3>();

        foreach (var respawnPoint in _respawnPoints)
        {
            if(closestPoints.Count < n)
            {
                closestPoints.Add(respawnPoint.position);
            }
            else
            {
                foreach (Vector3 point in closestPoints)
                {
                    float savedPointDistance = Vector3.Distance(point, playerPosition);
                    float checkingPointDistance = Vector3.Distance(respawnPoint.position,playerPosition);
                    if(checkingPointDistance < savedPointDistance)
                    {
                        closestPoints.Remove(point);
                        closestPoints.Add(respawnPoint.position);
                    }
                }
            }
        }
        return closestPoints.ToArray();
    }  
}