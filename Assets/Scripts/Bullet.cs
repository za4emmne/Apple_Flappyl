using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _direction;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
