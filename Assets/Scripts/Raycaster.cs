using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private float _maxDistanceRay = 1000;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Camera _camera;

    private Ray _ray;

    public event Action<Cube> GetIntoCube;

    private void OnEnable()
    {
        _inputReader.ButtonClicked += PointSomeCube;
    }

    private void OnDisable()
    {
        _inputReader.ButtonClicked -= PointSomeCube;
    }

    private void PointSomeCube(Vector3 clickPointPosition)
    {
        _ray = _camera.ScreenPointToRay(clickPointPosition);

        if (Physics.Raycast(_ray, out RaycastHit hit, _maxDistanceRay))
        {
            if (hit.collider.TryGetComponent(out Cube cube))
            {
                GetIntoCube?.Invoke(cube);
            }
        }
    }
}
