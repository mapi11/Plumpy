using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyScript : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public float patrolDistance = 10f;
    public bool movingRight = true;
    public float turnProbability = 0.2f;
    private float initialPosition;
    private float patrolRadius;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position.x;
        patrolRadius = initialPosition + patrolDistance;
    }

    void Update()
    {
        if (movingRight)
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
            if (transform.position.x >= patrolRadius)
            {
                if (Random.value < turnProbability)
                {
                    ChangeDirection();
                }
            }
        }
        else
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
            if (transform.position.x <= initialPosition)
            {
                if (Random.value < turnProbability)
                {
                    ChangeDirection();
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        // Обновляем радиус патрулирования
        patrolRadius = movingRight ? initialPosition + patrolDistance : initialPosition;
    }
}
