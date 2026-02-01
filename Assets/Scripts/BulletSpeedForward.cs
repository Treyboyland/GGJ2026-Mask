using UnityEngine;

public class BulletSpeedForward : BulletSpeed
{
    float speed;

    public override float Speed
    {
        get => speed; set
        {
            speed = value;
            body.linearVelocity = transform.up.normalized * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
