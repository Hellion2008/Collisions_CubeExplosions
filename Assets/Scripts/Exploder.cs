using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    
    private Spawner _spawner;
    private ChanceSpawn _chanceSpawn;

    private void Start()
    {
        _spawner = GetComponent<Spawner>();
        _chanceSpawn = GetComponent<ChanceSpawn>();
    }

    public void Explode(List<Rigidbody> cubes)
    {
        foreach (Rigidbody cube in cubes)
        {
            cube.AddExplosionForce(
                _explosionForce, 
                new Vector3 (CalculatePositionX(_spawner.Cubes), transform.position.y, transform.position.z), 
                _explosionRadius);
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
