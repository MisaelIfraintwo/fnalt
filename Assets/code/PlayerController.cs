using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public TMP_Text vidasText;


    public int maxHealt = 3;
    private int currentHealt;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealt = maxHealt;
        UpdateVidasUI();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        if (currentHealt > 0)
        {
            currentHealt--; 
            UpdateVidasUI(); 
        }

        if (currentHealt <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        SceneManager.LoadScene("DEATH");

    }
    void UpdateVidasUI()
    {
        if (vidasText != null)
        {
            vidasText.text = new string('V', currentHealt);
        }
        else
        {
            Debug.LogError(" No.");
        }
    }
}
