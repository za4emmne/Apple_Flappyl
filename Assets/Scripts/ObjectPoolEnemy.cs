using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEnemy : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _enemy;

    private Queue<Enemy> _pool;

    public IEnumerable<Enemy> PoolObjects => _pool;

    private void Awake()
    {
        _pool = new Queue<Enemy>();
    }

    public Enemy GetObject()
    {
        if (_pool.Count == 0)
        {
            var enemy = Instantiate(_enemy);
            return enemy;
        }

        return _pool.Dequeue();
    }

    public void PutObject(Enemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}
