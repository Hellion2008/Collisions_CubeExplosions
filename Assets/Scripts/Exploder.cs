using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    
    private Spawner _spawner;

    private void Start()
    {
        _spawner = GetComponent<Spawner>();
    }

    public void Explode(List<GameObject> cubes)
    {
        foreach (GameObject cube in cubes)
        {
            Rigidbody cubeRigidbody = cube.GetComponent<Rigidbody>();
            cubeRigidbody.AddExplosionForce(
                _explosionForce,
                new Vector3(CalculatePositionX(cubes), cube.transform.position.y, cube.transform.position.z),
                _explosionRadius);
        }
    }

    private float CalculatePositionX(List<GameObject> spawnObjects)
    {
        float sumX = 0f;

        foreach (GameObject cube in spawnObjects)
        {
            sumX += cube.transform.position.x;
        }

        return sumX / spawnObjects.Count;
    }
}
