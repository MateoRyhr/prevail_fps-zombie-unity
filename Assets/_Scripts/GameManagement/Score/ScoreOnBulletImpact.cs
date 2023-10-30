using System;
using UnityEngine;

public class ScoreOnBulletImpact : MonoBehaviour
{
    [SerializeField] private PlayerScoreForCombat _scoreForCombat;
    
    private ICollision _collisionGetter;
    private IGameObject _gameObjectGetter;

    private PlayerScore _playerScore;

    const string HEADSHOT_TAG = "head";

    private void Awake()
    {
        _gameObjectGetter = GetComponent<IGameObject>();
        _collisionGetter = GetComponent<ICollision>();
    }

    public void Score()
    {
        _playerScore = _gameObjectGetter.GameObject.GetComponentInChildren<PlayerScore>();
        float score = 0;
        Collision collision = _collisionGetter.Collision;
        var healthComponent = collision.gameObject.GetComponent<HealthEntitySubComponent>();
        if(healthComponent == null) return;
        bool headshot = collision.gameObject.tag == HEADSHOT_TAG;
        if(!headshot)
            score += _scoreForCombat.BulletImpactScore();
        else
            score += _scoreForCombat.HeadBulletImpactScore();

        if(healthComponent.HealthEntity.Health.Value <= 0)
            if(!headshot)
                score += _scoreForCombat.KillScore();
            else
                score += _scoreForCombat.KillWithHeadshotScore();

        if(score > 0)
            _playerScore.Add(score);
    }
}
