using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    public void Shoot(Transform shootPoint, Quaternion quaternion, float speed)
    { 
        _bullet.SetSpeed(speed);
        Instantiate(_bullet, shootPoint.position, quaternion);

    }

}
