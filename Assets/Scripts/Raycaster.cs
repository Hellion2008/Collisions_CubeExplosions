using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    private const string TagCube= "Interactable";

    [SerializeField] private InputReader _inputReader;

    private Camera _camera;
    private Ray _ray;

    public event Action ClickedOnCube;

    private void OnEnable()
    {
        _inputReader.OnClicked += FindSomeCube;
    }

    private void Start()
    {
        _camera = FindFirstObjectByType<Camera>();
    }

    private void OnDisable()
    {
        _inputReader.OnClicked -= FindSomeCube;
    }

    private void FindSomeCube()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag(TagCube))
            {
                ClickedOnCube?.Invoke();
            }

        }
    }
}
