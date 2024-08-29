using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private float _health;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            _weapon.Shoot(_shootPoint);
            yield return wait;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet))
        {
            Destroy(gameObject);
        }
    }
}