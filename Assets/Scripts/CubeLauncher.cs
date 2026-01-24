using System.Collections.Generic;
using UnityEngine;

public class CubeLauncher : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Explosion _explosion;

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
            else
            {
                _explosion.ExplodeAroundCube(pointedCube);
            }

                _spawner.DestroyCube(pointedCube);
        }
    }
}
