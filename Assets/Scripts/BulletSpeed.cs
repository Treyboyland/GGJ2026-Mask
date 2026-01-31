using UnityEngine;

public abstract class BulletSpeed : MonoBehaviour
{
    [SerializeField]
    protected Rigidbody2D body;

    public abstract float Speed { get; set; }
}
