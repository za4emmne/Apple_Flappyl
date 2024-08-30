using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private Quaternion _bulletRotation;

    public void Shoot(Transform transform)
    {
        _bulletSpawner.GetObjectFromPool(transform, _bulletRotation);
    }
}
