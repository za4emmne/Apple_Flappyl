using UnityEngine;

public class ObjectRemover<T, K> : MonoBehaviour where T : SpawnerObjects<K> where K : MonoBehaviour
{
    [SerializeField] private T _spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        K objectK;

        if (objectK = collision.GetComponent<K>())
            _spawner.Release(objectK);
    }
}
