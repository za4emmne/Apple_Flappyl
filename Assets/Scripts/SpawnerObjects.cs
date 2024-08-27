using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnerObjects<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private float _delay;
    [SerializeField] private float _minDelayOnSpawn;
    [SerializeField] private float _maxDelayOnSpawn;
    [SerializeField] private int _minCountObjectsInSpawn;
    [SerializeField] private int _maxCountObjectsInSpawn;
    [SerializeField] private int _poolCapacity;
    [SerializeField] private int _poolMaxSize;
    [SerializeField] private bool _globalSpawn;

    [SerializeField] private float _upBand;
    [SerializeField] private float _downBand;

    private ObjectPool<T> _objectPool;
    private List<T> _activeObjects;
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        _activeObjects = new List<T>();

        _objectPool = new ObjectPool<T>
        (
            createFunc: () => Create(GetRandomPosition()),
            actionOnGet: (spawnObject) => OnGet(spawnObject),
            actionOnRelease: (spawnObject) => OnRelease(spawnObject),
            actionOnDestroy: (spawnObject) => Delete(spawnObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
    }

    private void Update()
    {
        if (_spawnCoroutine == null)
            _spawnCoroutine = StartCoroutine(SpawnWithDelay());
    }

    public void GetObjectFromPool(Transform transform)
    {
        T objectFromPool = _objectPool.Get();
        objectFromPool.gameObject.transform.position = transform.position;
    }

    public virtual void OnGet(T spawnObject)
    {
        spawnObject.gameObject.SetActive(true);
        _activeObjects.Add(spawnObject);
    }

    public virtual void OnRelease(T spawnObject)
    {
        spawnObject.gameObject.SetActive(false);
        _activeObjects.Remove(spawnObject);
    }

    public virtual T Create(Vector2 vector2)
    {
        T spawnObject = Instantiate(_prefab, vector2, transform.rotation);

        return spawnObject;
    }

    public virtual void Delete(T spawnObject)
    {
        Destroy(spawnObject.gameObject);
    }

    public virtual void Release(T spawnObject)
    {
        _objectPool.Release(spawnObject);
    }

    public void Restart()
    {
        for (int i = _activeObjects.Count - 1; i >= 0; i--)
        {
            _objectPool.Release(_activeObjects[i]);
        }
    }

    protected Vector2 GetRandomPosition()
    {
        float spawnPositionY = Random.Range(_downBand, _upBand);

        return new Vector2(transform.position.x, spawnPositionY);
    }

    private IEnumerator SpawnWithDelay()
    {
        float delayOnSpawn = Random.Range(_minDelayOnSpawn, _maxDelayOnSpawn);

        WaitForSeconds wait = new WaitForSeconds(_delay);
        WaitForSeconds waitOnSpawn = new WaitForSeconds(delayOnSpawn);

        int countObjectsInSpawn = Random.Range(_minCountObjectsInSpawn, _maxCountObjectsInSpawn);

        for (int i = 0; i < countObjectsInSpawn; i++)
        {
            _objectPool.Get();
            yield return waitOnSpawn;
        }

        yield return wait;

        _spawnCoroutine = null;
    }
}
