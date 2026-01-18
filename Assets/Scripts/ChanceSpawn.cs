using UnityEngine;

public class ChanceSpawn : MonoBehaviour
{
    private const float ChangingChanceScale = 0.5f;

    [SerializeField] private float _chance = 1f;

    public void ChangeChance()
    {
        _chance *= ChangingChanceScale;
    }
    public bool CanSpawn()
    {
        float randomChance = UserUtils.GenerateRandomFloat();
        return randomChance < _chance;
    }
}
