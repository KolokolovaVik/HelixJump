using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Beam _beamTemplate;
    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private FinishPlatforn _finishPlatforn;

    private float _startAndEndAdditionalScale = 0.5f;

    public float BeamScaleY => _levelCount / 2f + _startAndEndAdditionalScale + _additionalScale / 2f;

    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        Beam beam = Instantiate(_beamTemplate, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y = beam.transform.localScale.y - _additionalScale;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition, beam.transform);
        }

        SpawnPlatform(_finishPlatforn, ref spawnPosition, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;
    }
}
