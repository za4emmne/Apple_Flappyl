using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletSpawner : SpawnerObjects<Bullet>
{
    [SerializeField] private EnemyGenerator _enemySpawner;

    public event UnityAction HitEnemy;
    public override void OnGet(Bullet bullet)
    {
        bullet.Collision += ReleaseOnCollision;
        base.OnGet(bullet);
    }

    private void ReleaseOnCollision(Enemy enemy, Bullet bullet)
    {
        Release(bullet);
        _enemySpawner.Release(enemy);
        HitEnemy?.Invoke();
    }
}
