using UnityEngine;

public class UserUtils : MonoBehaviour
{
    public static int GenerateRandomCount(int min, int max) =>
            Random.Range(min, max);

    public static float GenerateRandomFloat() => Random.Range(0.0f, 1.0f);
}
