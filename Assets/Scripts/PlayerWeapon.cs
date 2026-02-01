using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField]
    float secondsBetweenShots;

    [SerializeField]
    BulletPool playerBulletPool;

    [SerializeField]
    Player player;

    bool isFiring;

    float elapsed = 0;

    public bool IsFiring { set => isFiring = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (!isFiring)
        {
            elapsed = secondsBetweenShots;
        }
        else if (elapsed >= secondsBetweenShots)
        {
            elapsed = 0;
            FireBullet();
        }
    }

    public void FireBullet()
    {
        var bullet = playerBulletPool.GetObject();

        bullet.transform.position = transform.position;
        bullet.Color = player.Color;
        bullet.Faction = player.Faction;

        bullet.gameObject.SetActive(true);
        bullet.Stats = bullet.Stats;
    }
}
