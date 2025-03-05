using UnityEngine;
using UnityEngine.EventSystems;
public class gun : MonoBehaviour
{
    public GameObject bulletPrefab;  
    public Transform firePoint;      
    public float bulletSpeed = 10f;  
    public float fireRate = 0.2f;    
    private float nextFireTime = 0f;

    public Transform player;  
    public float weaponDistance = 0.5f; 

    void Update()
    {
        RotateWeaponAroundPlayer();

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void RotateWeaponAroundPlayer()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - player.position).normalized;  
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        
        transform.position = player.position + (Vector3)direction * weaponDistance;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.right * bulletSpeed;
    }
}