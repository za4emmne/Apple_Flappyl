using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    public void Shoot(Transform shootPoint)
    {
        Instantiate(_bullet, shootPoint.position, Quaternion.identity);
    }

}
