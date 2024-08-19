using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _upBand;
    [SerializeField] private float _downBand;
    [SerializeField] private ObjectPoolEnemy _objectPool;

    private void Start()
    {
        StartCoroutine(GeneratorEnemy());
    }

    private IEnumerator GeneratorEnemy()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_downBand, _upBand);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, 0);

        var enemy = _objectPool.GetObject();

        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
