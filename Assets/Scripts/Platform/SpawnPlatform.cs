using UnityEngine;

public class SpawnPlatform : Platform
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPointBall;

    private void Awake()
    {
        Instantiate(_ball, _spawnPointBall.position, Quaternion.identity);
    }
}
