using System.Collections.Generic;
using UnityEngine;

public class ParentCubeDestroyer : MonoBehaviour
{
    private Spawner _spawner;
    private Exploder _exploder;
    private Raycaster _raycaster;

    private void Awake()
    {
        _spawner = FindAnyObjectByType<Spawner>();
        _exploder = FindAnyObjectByType<Exploder>();
        _raycaster = FindAnyObjectByType<Raycaster>();
    }

    private void OnEnable()
    {
        _raycaster.GetIntoCube += CreateCubesWithExplosion;
    }

    private void OnDisable()
    {
        _raycaster.GetIntoCube += CreateCubesWithExplosion;
    }

    private void CreateCubesWithExplosion(GameObject prefab)
    {
        if (prefab != null)
        {
            Cube cube = prefab.GetComponent<Cube>();

            if (cube.CanSpawn())
            {
                List<GameObject> cubes = _spawner.SpawnCubes(prefab);
                _exploder.Explode(cubes);
            }

            _spawner.DestroyParentCube(cube);
        }
    }
}
