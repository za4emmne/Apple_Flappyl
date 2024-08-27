using System.Collections;
using UnityEngine;

public class EnemyGenerator : SpawnerObjects<Enemy>
{
    public override void OnGet(Enemy enemy)
    {
        enemy.transform.position = GetRandomPosition();
        base.OnGet(enemy);
    }
}
