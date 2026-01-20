using UnityEngine;

public class Cube : MonoBehaviour
{
    private const float ChangingChanceScale = 0.5f;

    [SerializeField] private float _chanceSpawn = 1f;

    public void ChangeChance()
    {
        _chanceSpawn *= ChangingChanceScale;
    }
    public bool CanSpawn()
    {
        float randomChance = Random.value;
        return randomChance < _chanceSpawn;
    }
}
