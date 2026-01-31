using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    DisableAfterTime disabler;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    ColorSO color;

    [SerializeField]
    BulletStatsSO stats;

    [SerializeField]
    FactionSO faction;

    [SerializeField]
    BulletSpeed bulletSpeed;



    public ColorSO Color
    {
        get => color;
        set
        {
            color = value;
            spriteRenderer.color = color.Color;
        }
    }

    public BulletStatsSO Stats
    {
        get => stats;
        set
        {
            stats = value;
            disabler.Seconds = stats.LifeTime;
            bulletSpeed.Speed = stats.Speed;
        }
    }

    public FactionSO Faction { get => faction;  }
}
