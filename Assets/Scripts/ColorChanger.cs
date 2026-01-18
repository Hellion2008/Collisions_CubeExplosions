using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        ChangeColor();
    }

    private void ChangeColor()
    { 
        if (_renderer != null)
        {
            float r = UserUtils.GenerateRandomFloat();
            float g = UserUtils.GenerateRandomFloat();
            float b = UserUtils.GenerateRandomFloat();
            _renderer.materials[0].color = new Color(r, g, b);
        }
    }
}
