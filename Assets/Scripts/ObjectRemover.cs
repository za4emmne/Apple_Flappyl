using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private ObjectPoolEnemy _poolEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Pipe pipe))
            _pool.PutObject(pipe);

        if (collision.TryGetComponent(out Enemy enemy))
            _poolEnemy.PutObject(enemy);

        if (collision.TryGetComponent(out Bullet bullet))
            Destroy(bullet.gameObject);
    }
}
