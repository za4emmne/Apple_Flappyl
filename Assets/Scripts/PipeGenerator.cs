using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _upBand;
    [SerializeField] private float _downBand;
    [SerializeField] private ObjectPool _objectPool;

    private void Start()
    {
        StartCoroutine(GeneratorPipe());
    }

    private IEnumerator GeneratorPipe()
    {
        var wait = new WaitForSeconds(_delay);

        while(enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_downBand, _upBand);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var pipe = _objectPool.GetObject();

        pipe.gameObject.SetActive(true);
        pipe.transform.position = spawnPoint;
    }
}
