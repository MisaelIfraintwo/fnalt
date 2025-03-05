using UnityEngine;
using UnityEngine.EventSystems;
public class gun : MonoBehaviour
{
    public GameObject bulletPrefab;  // Prefab de la bala
    public Transform firePoint;      // Punto de disparo (hijo del arma)
    public float bulletSpeed = 10f;  // Velocidad de la bala
    public float fireRate = 0.2f;    // Tiempo entre disparos
    private float nextFireTime = 0f;

    public Transform player;  // Referencia al personaje
    public float weaponDistance = 0.5f;  // Distancia del arma con respecto al personaje

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
        Vector2 direction = (mousePos - player.position).normalized;  // Dirección hacia el mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Posiciona el arma con un offset respecto al jugador
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