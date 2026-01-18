using UnityEngine;

public class Controller : MonoBehaviour
{
    private Spawner _spawner;
    private ChanceSpawn _chanceSpawn;
    private Exploder _exploder;
    private Raycaster _raycaster;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        _chanceSpawn = GetComponent<ChanceSpawn>();
        _exploder = GetComponent<Exploder>();
        _raycaster = GetComponent<Raycaster>();
    }

    private void OnEnable()
    {
        _raycaster.ClickedOnCube += TryToSpawnCubes;
    }

    private void OnDisable()
    {
        _raycaster.ClickedOnCube += TryToSpawnCubes;
    }

    private void TryToSpawnCubes()
    {
        if (_spawner != null)
        {
            if (_chanceSpawn.CanSpawn())
            {
                _spawner.SpawnCubes();
                _exploder.Explode(_spawner.Cubes);
            }

            Destroy(gameObject);
        }
    }
}
