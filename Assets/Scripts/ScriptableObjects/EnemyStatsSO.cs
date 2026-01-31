using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats-", menuName = "Game Stuff/Stats/Enemy Stats")]
public class EnemyStatsSO : ScriptableObject
{
    [SerializeField]
    int health;

    public int Health { get => health; }
}
