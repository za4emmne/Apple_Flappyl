using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private BulletSpawner _bulletSpawner;

    public void Shoot(Transform shootPoint)
    { 
        _bulletSpawner.GetObjectFromPool(shootPoint);
    }
}
