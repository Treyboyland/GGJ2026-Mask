using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats-", menuName = "Game Stuff/Stats/Enemy Stats")]
public class EnemyStatsSO : ScriptableObject
{
    [SerializeField]
    int health;

    [SerializeField]
    int points;

    [SerializeField]
    float speed;

    public int Health { get => health; }
    public float Speed { get => speed; }
    public int Points { get => points; }
}
