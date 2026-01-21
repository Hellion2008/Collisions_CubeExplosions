using System.Collections.Generic;
using UnityEngine;

public class CubeLauncher : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;

    private void OnEnable()
    {
        _raycaster.GetIntoCube += CreateCubesWithExplosion;
    }

    private void OnDisable()
    {
        _raycaster.GetIntoCube += CreateCubesWithExplosion;
    }

    private void CreateCubesWithExplosion(Cube pointedCube)
    {
        if (pointedCube != null)
        {
            if (pointedCube.CanSpawn())
            {
                List<Cube> cubes = _spawner.SpawnCubes(pointedCube);
                _exploder.Explode(cubes);
            }

            _spawner.DestroyCube(pointedCube);
        }
    }
}
