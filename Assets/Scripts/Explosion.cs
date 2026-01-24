using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private const float OriginExplosionRadius = 10f;
    private const float OriginExplosionForce = 500f;
    private const float Scale = 0.8f;

    [SerializeField] private float _explosionRadius = OriginExplosionRadius;
    [SerializeField] private float _explosionForce = OriginExplosionForce;

    public void ExplodeAroundCube(Cube cube)
    {
        foreach (Rigidbody exploableObject in GetExplodableObjects(cube))
        {
            exploableObject.AddExplosionForce(
                CalculateScaleValue(_explosionForce, cube), 
                cube.transform.position,
                CalculateScaleValue(_explosionRadius, cube)
            );
        }
    }

    private List<Rigidbody> GetExplodableObjects(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _explosionRadius);

        List<Rigidbody> explodableCubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                explodableCubes.Add(hit.attachedRigidbody);
            }
        }

        return explodableCubes;
    }

    private float CalculateScaleValue(float value, Cube cube)
    {
        float cubeScale = cube.transform.localScale.x;

        if (cubeScale >= 1)
        {
            cubeScale = Scale;
        }

        return value / cubeScale;
    }
}
