using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int MinCountCubes = 2;
    private const int MaxCountCubes = 6;

    [SerializeField, Min(MinCountCubes)] private int _lowLimitCountCubes;
    [SerializeField] private int _highLimitCountCubes = MaxCountCubes;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _scaleCube = 0.5f;

    public List<Rigidbody> Cubes => GetRigidbodyCubes(
        transform.position,
        UserUtils.GenerateRandomCount(_lowLimitCountCubes, _highLimitCountCubes));

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

    public void SpawnCubes()
    {
        for (int i = 0; i < Cubes.Count; i++)
        {
            GameObject cube = Instantiate(_prefab, Cubes[0].transform.position, transform.rotation);
            cube.transform.localScale *= _scaleCube;

            ChanceSpawn chanceSpawn = cube.GetComponent<ChanceSpawn>();
            chanceSpawn.ChangeChance();
        }
    }

    private List<Rigidbody> GetRigidbodyCubes(Vector3 spawnPositionTransform, int countCubes)
    {
        List<Rigidbody> spawnObjects = new List<Rigidbody>();

        for (int i = 0; i < countCubes; i++)
        {
            var offsetX = gameObject.transform.localScale.x * _scaleCube;
            spawnPositionTransform.x += offsetX;

            Rigidbody instantiateCubeRigidbody = GetComponent<Rigidbody>();
            spawnObjects.Add(instantiateCubeRigidbody);
        }

        return spawnObjects;
    }
}
