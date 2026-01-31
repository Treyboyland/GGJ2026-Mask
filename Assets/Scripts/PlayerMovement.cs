using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    float speed;

    [SerializeField]
    Vector2 bounds;

    Vector2 movementVector;

    public Vector2 MovementVector { set => movementVector = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void FixedUpdate()
    {
        movementVector.y = 0;
        var newPos = (Vector2)transform.position + movementVector * speed * Time.fixedDeltaTime;
        newPos.x = Mathf.Max(Mathf.Min(bounds.y, newPos.x), bounds.x);
        body.MovePosition(newPos);
    }
}
