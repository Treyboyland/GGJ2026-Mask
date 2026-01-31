using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    ColorSO color;

    [SerializeField]
    int startingHealth;

    int health;
    public ColorSO Color
    {
        get
        {
            return color;
        }
        set
        {
            color = value;
            sprite.color = color.Color;
        }
    }

    internal void Damage(int v)
    {
        health -= v;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Color = color;
        health = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
