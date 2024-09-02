using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private BulletSpawner _spawner;

    private int _value;

    public event Action<int> Changed;

    private void OnEnable()
    {
        _spawner.HitEnemy += Add;
    }

    private void OnDisable()
    {
        _spawner.HitEnemy -= Add;
    }

    public void Add()
    {
        _value++;
        Changed?.Invoke(_value);
    }

    public void Reset()
    {
        _value = 0;
        Changed?.Invoke(_value);
    }
}
