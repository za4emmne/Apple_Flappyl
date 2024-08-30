using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour, IInteractable
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _direction;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //_rigidbody.velocity = transform.rotation * _direction;
        _rigidbody.velocity = transform.right * _speed;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
