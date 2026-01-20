using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private float _maxDistanceRay = 1000;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Camera _camera;

    private Ray _ray;

    public event Action<GameObject> GetIntoCube;

    private void OnEnable()
    {
        _inputReader.OnClicked += PointSomeCube;
    }

    private void OnDisable()
    {
        _inputReader.OnClicked -= PointSomeCube;
    }

    private void PointSomeCube(Vector3 cubePosition)
    {
        _ray = _camera.ScreenPointToRay(cubePosition);

        if (Physics.Raycast(_ray, out RaycastHit hit, _maxDistanceRay))
        {
            if (hit.collider.TryGetComponent<Cube>(out Cube cube))
            {
                GetIntoCube?.Invoke(cube.gameObject);
            }
        }
    }
}
