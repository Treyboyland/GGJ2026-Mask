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
    ColorSO white;

    [SerializeField]
    ColorSO startingColor;

    int currentHealth;

    ColorSO color;

    public ColorSO Color
    {
        get => color; set
        {
            color = value;
            spriteRenderer.color = color.Color;
        }
    }

    void OnEnable()
    {
        currentHealth = statsSO.Health;
        Color = startingColor;
    }

    void Damage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    void HandleBullet(Bullet bullet)
    {
        if (bullet.Color != color && bullet.Color == white)
        {
            Damage(bullet.Stats.Damage);
            bullet.gameObject.SetActive(false);
        }
        else if (bullet.Color == color)
        {
            Damage(2 * bullet.Stats.Damage);
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
                player.Damage(1);
            }
        }
    }



}
