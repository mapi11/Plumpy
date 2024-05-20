using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModernEnemyScript : MonoBehaviour
{
    [Space]
    [Header("Enemy settings")]
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [Space]
    [Header("Speed")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float attackSpeed = 4f;
    [SerializeField] private bool movingRight = true;
    [Space]
    [Header("Patrol & direction")]
    [SerializeField] private float patrolDistance = 10f;
    private float turnProbability = 1f;
    [Space]
    [SerializeField] private float timeUntilTurn; // ����� �� ���������� ���������
    [SerializeField] private float turnIntervalMin = 3f; // ����������� ����� �� ���������
    [SerializeField] private float turnIntervalMax = 20f; // ������������ ����� �� ���������
    //[SerializeField] private float initialPosition;
    //private float patrolRadius;

    [Space]
    [Header("Damage & attack")]
    [SerializeField] private int _damage = 1;
    [SerializeField] private float attackRange = 2f;
    private float attackCooldown = 2f;
    private float lastAttackTime = -999f;

    [SerializeField] private float detectionRange = 5f;

    private bool playerDetected = false;

    private Vector3 lastKnownPlayerPosition;
    private Vector3 lostPlayerPosition;

    CharacterHealthScript _haracterHealthScript;

    void Start()
    {
        _haracterHealthScript = FindAnyObjectByType<CharacterHealthScript>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        //initialPosition = transform.position.x;
        //patrolRadius = initialPosition + patrolDistance;

        timeUntilTurn = Random.Range(turnIntervalMin, turnIntervalMax);
        //Patrol();
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
                MoveTowards(lostPlayerPosition); // ���������� �������� � �������, ��� ��� ������� �����
            }
            else
            {
                MoveTowards(player.position); // ���������� ������
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

        if (timeUntilTurn > 0)
        {
            timeUntilTurn -= Time.deltaTime;
        }
        else
        {
            if (Random.Range(0f, 1f) < turnProbability && playerDetected == false)
            {
                Stop();
                ChangeDirection();
                lostPlayerPosition = transform.position;
            }
            timeUntilTurn = Random.Range(turnIntervalMin, turnIntervalMax);
        }
    }

    void Patrol()
    {
        if (movingRight)
        {
            rb.velocity = new Vector3(moveSpeed, rb.velocity.y, 0);
            if (transform.position.x >= lostPlayerPosition.x + patrolDistance) // �������� ������� ��� ����� ����� ��������������
            {
                if (Random.Range(0f, 0.5f) > turnProbability)
                {
                    ChangeDirection();
                    lostPlayerPosition = transform.position; // ��������� �������, ��� ��� ������� �����
                }
            }
        }
        else
        {
            rb.velocity = new Vector3(-moveSpeed, rb.velocity.y, 0);
            if (transform.position.x <= lostPlayerPosition.x - patrolDistance) // �������� ������� ��� ����� ����� ��������������
            {
                if (Random.Range(0f, 1f) > turnProbability)
                {
                    
                    ChangeDirection();
                    lostPlayerPosition = transform.position; // ��������� �������, ��� ��� ������� �����
                }
            }
        }
    }

    void MoveTowards(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction.Normalize();
        rb.velocity = new Vector3(direction.x * attackSpeed, rb.velocity.y, 0);

        // ������� ��������� � ����������� ��������
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
        _haracterHealthScript.Damage(_damage);
        // ������ �����
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