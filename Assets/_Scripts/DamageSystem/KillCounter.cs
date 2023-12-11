using UnityEngine;

public class KillCounter : MonoBehaviour
{
    private IGameObject _gameObjectGetter;

    private PlayerKills _playerKills => _gameObjectGetter.GameObject.GetComponentInChildren<PlayerKills>();

    private void Awake()
    {
        _gameObjectGetter = GetComponent<IGameObject>();
    }

    public void AddKill()
    {
        _playerKills.Add(1);
    }
}
