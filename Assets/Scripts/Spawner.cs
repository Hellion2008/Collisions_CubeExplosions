using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int MinCountCubes = 2;
    private const int MaxCountCubes = 6;
    private const float ScaleCube = 0.5f;

    [SerializeField, Min(MinCountCubes)] private int _lowLimitCountCubes;
    [SerializeField] private int _highLimitCountCubes = MaxCountCubes;

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

    public List<Cube> SpawnCubes(Cube pointedCube)
    {
        List<Cube> spawnObjects = new ();
        int countCubes = Random.Range(_lowLimitCountCubes, _highLimitCountCubes);

        float positionX = pointedCube.transform.position.x;

        for (int i = 0; i < countCubes; i++)
        {
            Cube cube = Instantiate(
                pointedCube, 
                new Vector3 (positionX, pointedCube.transform.position.y, pointedCube.transform.position.z),
                Quaternion.identity);
            cube.transform.localScale *= ScaleCube;

            if (cube.TryGetComponent<Cube>(out _))
            {
                cube.ChangeChance();
                spawnObjects.Add(cube);
                float offsetX = cube.transform.localScale.x * ScaleCube;
                positionX += offsetX;
            }
        }

        return spawnObjects;
    }

    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
