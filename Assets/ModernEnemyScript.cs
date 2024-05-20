using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModernEnemyScript : MonoBehaviour
{
    //public Transform player;
    //public Rigidbody rb;
    //public Animator animator;
    //public float moveSpeed = 5f;
    //public float patrolDistance = 10f;
    //public bool movingRight = true;
    //public float turnProbability = 0.2f;
    //private float initialPosition;
    //private float patrolRadius;

    //public float attackRange = 2f;
    //private float attackCooldown = 2f;
    //private float lastAttackTime = -999f;

    //public float detectionRange = 5f;

    //void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player").transform;
    //    //rb = GetComponent<Rigidbody>();
    //    //animator = GetComponent<Animator>();

    //    initialPosition = transform.position.x;
    //    patrolRadius = initialPosition + patrolDistance;
    //}

    //void Update()
    //{
    //    float distanceToPlayer = Vector3.Distance(transform.position, player.position);

    //    if (distanceToPlayer > detectionRange)
    //    {
    //        Patrol();
    //    }
    //    else
    //    {
    //        if (distanceToPlayer <= attackRange && Time.time - lastAttackTime >= attackCooldown)
    //        {
    //            Stop();
    //            Attack();
    //            lastAttackTime = Time.time;
    //        }
    //        else
    //        {
    //            if (!CheckObstacleInFront())
    //            {
    //                MoveTowards(player.position);
    //            }
    //            else
    //            {
    //                Stop();
    //            }
    //        }
    //    }
    //}

    //void Patrol()
    //{
    //    if (movingRight)
    //    {
    //        rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
    //        if (transform.position.x >= patrolRadius)
    //        {
    //            if (Random.value < turnProbability)
    //            {
    //                ChangeDirection();
    //            }
    //        }
    //    }
    //    else
    //    {
    //        rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
    //        if (transform.position.x <= initialPosition)
    //        {
    //            if (Random.value < turnProbability)
    //            {
    //                ChangeDirection();
    //            }
    //        }
    //    }
    //}

    //void MoveTowards(Vector3 targetPosition)
    //{
    //    Vector3 direction = targetPosition - transform.position;
    //    direction.Normalize();
    //    rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, 0);

    //    // Поворот персонажа в направлении движения
    //    if (direction.x > 0)
    //    {
    //        transform.localScale = new Vector3(1, 1, 1);
    //    }
    //    else if (direction.x < 0)
    //    {
    //        transform.localScale = new Vector3(-1, 1, 1);
    //    }
    //}

    //void Stop()
    //{
    //    rb.velocity = Vector2.zero;
    //    animator.SetFloat("MoveX", 0);
    //    //animator.SetFloat("MoveY", 0);
    //}

    //void Attack()
    //{
    //    // Логика атаки
    //    Debug.Log("Attack");
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        ChangeDirection();
    //    }
    //}

    //bool CheckObstacleInFront()
    //{
    //    Vector3 direction = movingRight ? Vector3.right : Vector3.left;
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, direction, out hit, 1f))
    //    {
    //        if (hit.collider.CompareTag("Wall"))
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    //void ChangeDirection()
    //{
    //    movingRight = !movingRight;
    //    Vector3 scale = transform.localScale;
    //    scale.x *= -1;
    //    transform.localScale = scale;

    //    // Обновляем радиус патрулирования
    //    patrolRadius = movingRight ? initialPosition + patrolDistance : initialPosition;
    //}

    public Transform player;
    public Rigidbody rb;
    public Animator animator;
    public float moveSpeed = 5f;
    public float patrolDistance = 10f;
    public bool movingRight = true;
    public float turnProbability = 0.2f;
    private float initialPosition;
    private float patrolRadius;

    public float attackRange = 2f;
    private float attackCooldown = 2f;
    private float lastAttackTime = -999f;

    public float detectionRange = 5f;

    private bool playerDetected = false;
    private Vector3 lastKnownPlayerPosition;

    private Vector3 lostPlayerPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        initialPosition = transform.position.x;
        patrolRadius = initialPosition + patrolDistance;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (playerDetected)
        {
            if (distanceToPlayer <= attackRange && Time.time - lastAttackTime >= attackCooldown)
            {
                Stop();
                Attack();
                lastAttackTime = Time.time;
            }
            else if (distanceToPlayer > detectionRange)
            {
                playerDetected = false;
                MoveTowards(lostPlayerPosition); // Продолжаем движение к позиции, где был потерян игрок
            }
            else
            {
                MoveTowards(player.position); // Преследуем игрока
            }

        }
        else
        {
            if (distanceToPlayer <= detectionRange)
            {
                playerDetected = true;
                lastKnownPlayerPosition = player.position;
            }
            else
            {
                Patrol();
            }
        }
    }

    void Patrol()
    {
        if (movingRight)
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
            if (transform.position.x >= lostPlayerPosition.x + patrolDistance) // Изменяем условие для новой точки патрулирования
            {
                if (Random.value < turnProbability)
                {
                    ChangeDirection();
                    lostPlayerPosition = transform.position; // Обновляем позицию, где был потерян игрок
                }
            }
        }
        else
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
            if (transform.position.x <= lostPlayerPosition.x - patrolDistance) // Изменяем условие для новой точки патрулирования
            {
                if (Random.value < turnProbability)
                {
                    ChangeDirection();
                    lostPlayerPosition = transform.position; // Обновляем позицию, где был потерян игрок
                }
            }
        }
    }

    void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction.Normalize();
        rb.velocity = new Vector3(direction.x * moveSpeed, rb.velocity.y, 0);

        // Поворот персонажа в направлении движения
        if (direction.x > 0 && !movingRight)
        {
            ChangeDirection();
        }
        else if (direction.x < 0 && movingRight)
        {
            ChangeDirection();
        }
    }

    void Stop()
    {
        rb.velocity = Vector2.zero;
        animator.SetFloat("MoveX", 0);
    }

    void Attack()
    {
        // Логика атаки
        Debug.Log("Attack");
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
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}