using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int MinCountCubes = 2;
    private const int MaxCountCubes = 6;
    private const float ChangingChanceScale = 0.5f;

    [SerializeField, Min(MinCountCubes)] private int _lowLimitCountCubes;
    [SerializeField] private int _highLimitCountCubes = MaxCountCubes;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _scaleCube = 0.5f;
    [SerializeField] private float _chance = 1f;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

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

    private void OnMouseUpAsButton()
    {
        if (canSpawn())
        {
            SpawnCubes(transform.position, UserUtils.GenerateRandomCount(_lowLimitCountCubes, _highLimitCountCubes));
        }

        Destroy(gameObject);
    }

    private void SpawnCubes(Vector3 spawnPositionTransform, int countCubes)
    {
        List<Rigidbody> spawnObjects = new List<Rigidbody>();

        for (int i = 0; i < countCubes; i++)
        {
            var offsetX = gameObject.transform.localScale.x * _scaleCube;
            spawnPositionTransform.x += offsetX;

            GameObject cube = Instantiate(_prefab, spawnPositionTransform, transform.rotation);
            cube.transform.localScale *= _scaleCube;

            Spawner instantiateCube = cube.GetComponent<Spawner>();
            instantiateCube._chance = _chance * ChangingChanceScale;

            Rigidbody instantiateCubeRigidbody = cube.GetComponent<Rigidbody>();
            spawnObjects.Add(instantiateCubeRigidbody);
        }

        Explode(spawnObjects, new Vector3(
            CalculatePositionX(spawnObjects), spawnPositionTransform.y, spawnPositionTransform.z));
    }

    private bool canSpawn()
    {
        float randomChance = UserUtils.GenerateRandomFloat();
        return randomChance < _chance;
    }

    private void Explode(List<Rigidbody> cubes, Vector3 position)
    {
        foreach (Rigidbody cube in cubes)
        {
            cube.AddExplosionForce(_explosionForce, position, _explosionRadius);
        }
    }

    private float CalculatePositionX(List<Rigidbody> spawnObjects)
    {
        float sumX = 0f;

        foreach (Rigidbody cube in spawnObjects)
        {
            sumX += cube.position.x;
        }

        return sumX / spawnObjects.Count;
    }
}
