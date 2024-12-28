using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint; 
    public float bulletSpeed = 20f;
    public ParticleSystem muzzleFlash;
    public CameraShake cameraShake;
    public AudioSource audioSource; 
    public AudioClip shootSound;   

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {

        if (shootSound != null)
            audioSource.PlayOneShot(shootSound);
        /*  GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

          Rigidbody rb = bullet.GetComponent<Rigidbody>();
          if (rb != null)
          {
              rb.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);
          }

          Destroy(bullet, 5f); */
        muzzleFlash.Play();


        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        
        Camera mainCamera = Camera.main;
        Vector3 shootDirection = mainCamera.transform.forward;

        
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shootDirection * bulletSpeed, ForceMode.Impulse);
        }

        
        Destroy(bullet, 5f);

        StartCoroutine(cameraShake.Shake(0.1f, 0.1f));
    } 
}
