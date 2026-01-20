using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
        ChangeColor();
    }

    private void ChangeColor()
    { 
        if (_renderer != null)
        {
            _renderer.materials[0].color = Random.ColorHSV();
        }
    }
}
