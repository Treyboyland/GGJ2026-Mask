using UnityEngine;

[CreateAssetMenu(fileName = "BulletStats-", menuName = "Game Stuff/Stats/Bullet Stats")]
public class BulletStatsSO : ScriptableObject
{
    [SerializeField]
    float speed;

    [SerializeField]
    float lifeTime;

    [SerializeField]
    int damage;

    public float Speed { get => speed; }
    public float LifeTime { get => lifeTime; }
    public int Damage { get => damage; }
}
