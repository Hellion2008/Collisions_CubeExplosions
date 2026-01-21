using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const int ButtonClickToCube = 0;

    public event Action<Vector3> ButtonClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(ButtonClickToCube))
        {
            ButtonClicked?.Invoke(Input.mousePosition);
        }
    }
}
