using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event Action<Enemy>OnEnemyKilled;
    [SerializeField] float healt, maxHealt = 2f;

    [SerializeField] float moveSpeed = 3f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        healt = maxHealt;
        target = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
          
            moveDirection = direction; 
        }

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
    }
}