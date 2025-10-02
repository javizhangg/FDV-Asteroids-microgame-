using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance; 
    public GameObject bulletPrefab;
    public int poolSize = 10;
    private List<GameObject> bullets;

    private void Awake()
    {
        Instance = this; 
    }

    // Creamos las balas al inicio y las desactivamos
    void Start()
    {
        bullets = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bullets.Add(bullet);
        }
    }

    // Busca una bala inactiva
    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        // Si no hay balas disponibles, creamos una nueva
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.SetActive(false);
        bullets.Add(newBullet);
        return newBullet;
    }
}
