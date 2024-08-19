using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
