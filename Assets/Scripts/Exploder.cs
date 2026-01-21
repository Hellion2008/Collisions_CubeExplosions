using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private Spawner _spawner;

    public void Explode(List<Cube> cubes)
    {
        foreach (Cube cube in cubes)
        {
            if (cube.TryGetComponent(out Rigidbody cubeRigidbody))
            { 
                cubeRigidbody.AddExplosionForce(
                    _explosionForce,
                    new Vector3(CalculatePositionX(cubes), cube.transform.position.y, cube.transform.position.z),
                    _explosionRadius);
            }
        }
    }

    private float CalculatePositionX(List<Cube> spawnObjects)
    {
        float sumX = 0f;

        foreach (Cube cube in spawnObjects)
        {
            sumX += cube.transform.position.x;
        }

        return sumX / spawnObjects.Count;
    }
}
