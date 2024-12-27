using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint; 
    public float bulletSpeed = 20f; 

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {

        /*  GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

          Rigidbody rb = bullet.GetComponent<Rigidbody>();
          if (rb != null)
          {
              rb.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);
          }

          Destroy(bullet, 5f); */

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        
        Camera mainCamera = Camera.main;
        Vector3 shootDirection = mainCamera.transform.forward;

        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootDirection * bulletSpeed, ForceMode.Impulse);
        }

        
        Destroy(bullet, 5f);
    } 
}
