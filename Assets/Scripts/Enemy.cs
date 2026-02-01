using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    FactionSO faction;

    [SerializeField]
    EnemyStatsSO statsSO;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    EnemyMoveHorizontal horizontal;

    [SerializeField]
    EnemyMoveVertical vertical;

    [SerializeField]
    ColorSO white;

    [SerializeField]
    ColorSO startingColor;

    [SerializeField]
    GameEvent onHit;

    [SerializeField]
    GameEvent onPlayerHit;

    [SerializeField]
    GameEventEnemyDeathInfo onDeath;

    int currentHealth;

    bool horizontalMovement;

    ColorSO color;

    public ColorSO Color
    {
        get => color; set
        {
            color = value;
            spriteRenderer.color = color.Color;
        }
    }

    public EnemyStatsSO StatsSO { get => statsSO; }
    public ColorSO StartingColor { get => startingColor; set => startingColor = value; }

    public bool HorizontalMovement
    {
        get => horizontalMovement;
        set
        {
            horizontalMovement = value;
            horizontal.enabled = horizontalMovement;
            vertical.enabled = !horizontal.enabled;
        }
    }

    void OnEnable()
    {
        currentHealth = statsSO.Health;
        Color = startingColor;
    }

    void Damage(int amount, bool criticalHit)
    {
        currentHealth -= amount;
        if (amount > 0)
        {
            onHit.Invoke();
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die(criticalHit);
        }

    }

    private void Die(bool criticalHit)
    {
        onDeath.Invoke(new EnemyDeathInfo()
        {
            Vector3 = transform.position,
            Color = color,
            ColorMatched = criticalHit,
            EnemyStatsSO = statsSO
        });
        gameObject.SetActive(false);
    }

    void HandleBullet(Bullet bullet)
    {
        if (bullet.Color != color && bullet.Color == white)
        {
            Damage(bullet.Stats.Damage, false);
            bullet.gameObject.SetActive(false);
        }
        else if (bullet.Color == color)
        {
            Damage(2 * bullet.Stats.Damage, true);
            bullet.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet && bullet.Faction != faction)
        {
            HandleBullet(bullet);
        }
        else
        {
            var player = collision.gameObject.GetComponent<Player>();
            if (player)
            {
                onPlayerHit.Invoke();
            }
        }
    }



}
