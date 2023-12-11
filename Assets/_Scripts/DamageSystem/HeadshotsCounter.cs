using UnityEngine;

public class HeadshotsCounter : MonoBehaviour
{
    private IGameObject _gameObjectGetter;

    private PlayerHeadshots _playerHeadshots => _gameObjectGetter.GameObject.GetComponentInChildren<PlayerHeadshots>();

    private void Awake()
    {
        _gameObjectGetter = GetComponent<IGameObject>();
    }

    public void AddHeadshotKill() => _playerHeadshots.Add(1);
}
