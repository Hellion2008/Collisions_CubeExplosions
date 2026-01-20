using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int MinCountCubes = 2;
    private const int MaxCountCubes = 6;
    private const float ScaleCube = 0.5f;

    [SerializeField, Min(MinCountCubes)] private int _lowLimitCountCubes;
    [SerializeField] private int _highLimitCountCubes = MaxCountCubes;
    [SerializeField] private GameObject _prefab;

    private void OnValidate()
    {
        if (_lowLimitCountCubes >= _highLimitCountCubes)
        {
            _lowLimitCountCubes = _highLimitCountCubes - 1;

            if (_lowLimitCountCubes < MinCountCubes || _highLimitCountCubes < MinCountCubes)
            {
                _lowLimitCountCubes = MinCountCubes;
                _highLimitCountCubes = MinCountCubes;
            }
        }
    }

    public List<GameObject> SpawnCubes(GameObject prefab)
    {
        List<GameObject> spawnObjects = new List<GameObject>();
        int countCubes = Random.Range(_lowLimitCountCubes, _highLimitCountCubes);

        float positionX = prefab.transform.position.x;

        for (int i = 0; i < countCubes; i++)
        {
            GameObject cube = Instantiate(
                prefab, 
                new Vector3 (positionX, prefab.transform.position.y, prefab.transform.position.z),
                Quaternion.identity);
            cube.transform.localScale *= ScaleCube;

            Cube chanceSpawn = cube.GetComponent<Cube>();
            chanceSpawn.ChangeChance();

            spawnObjects.Add(cube);

            var offsetX = cube.transform.localScale.x * ScaleCube;
            positionX += offsetX;
        }

        return spawnObjects;
    }

    public void DestroyParentCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
