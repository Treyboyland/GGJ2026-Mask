using UnityEngine;

public class EnemyMoveVertical : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    float speed;

    static Player _player;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += Time.deltaTime * speed;
        transform.position = pos;
    }

    void FindPlayer()
    {
        if (_player == null)
        {
            _player = FindAnyObjectByType<Player>();
        }
    }

    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            FindPlayer();
            speed = enemy.StatsSO.Speed * (_player.transform.position.y > transform.position.y ? 1 : -1);
        }
    }
}
