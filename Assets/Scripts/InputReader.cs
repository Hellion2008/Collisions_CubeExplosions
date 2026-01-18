using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action OnClicked;

    private void OnMouseUpAsButton()
    {
        OnClicked?.Invoke();
    }
}
