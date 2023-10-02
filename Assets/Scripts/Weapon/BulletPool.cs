using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private int _initialPoolSize = 10;
    private List<Bullet> _bullets;

    private void Awake()
    {
        Instance = this;
        _bullets = new List<Bullet>(_initialPoolSize);

        for (int i = 0; i < _initialPoolSize; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform);
            bullet.gameObject.SetActive(false);
            _bullets.Add(bullet);
        }
    }

    public Bullet GetBullet()
    {
        foreach (Bullet bullet in _bullets)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                bullet.gameObject.SetActive(true);
                return bullet;
            }
        }

        Bullet newBullet = Instantiate(_bulletPrefab, transform);
        _bullets.Add(newBullet);
        return newBullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}
