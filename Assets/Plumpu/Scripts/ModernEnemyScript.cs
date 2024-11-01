using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

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
    bool isAttacking = false;

    [SerializeField] private float detectionRange = 5f;

    private bool playerDetected = false;

    private Vector3 lastKnownPlayerPosition;
    private Vector3 lostPlayerPosition;

    CharacterHealthScript _haracterHealthScript;
    MainCharacterControllerScript _characterControllerScript;

    void Start()
    {
        _haracterHealthScript = FindAnyObjectByType<CharacterHealthScript>();
        _characterControllerScript = FindAnyObjectByType<MainCharacterControllerScript>();

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
                Attack();
                lastAttackTime = Time.time;
                //animator.SetBool("IsAttack", false);
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
                
                ChangeDirection();
                lostPlayerPosition = transform.position;
            }
            timeUntilTurn = Random.Range(turnIntervalMin, turnIntervalMax);
        }
    }

    private void FixedUpdate()
    {
        //animator.SetFloat("xVelocity",Math)
    }

    void Patrol()
    {
        if (movingRight)
        {
            rb.linearVelocity = new Vector3(moveSpeed, rb.linearVelocity.y, 0);
            animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));

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
            rb.linearVelocity = new Vector3(-moveSpeed, rb.linearVelocity.y, 0);
            animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));
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
        if (!isAttacking)
        {
            Vector3 direction = targetPosition - transform.position;
            direction.Normalize();
            rb.linearVelocity = new Vector3(direction.x * attackSpeed, rb.linearVelocity.y, 0);
            animator.SetFloat("xVelocity", Mathf.Abs(rb.linearVelocity.x));

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
    }


    void Attack()
    {
        animator.SetBool("IsAttack", true);
        if (!isAttacking)
        {
            isAttacking = true;
            // ������ �����
            Debug.Log("Attack");
            isAttacking = false;

            Invoke("StopAttack", 1f);
        }
    }

    private void StopAttack()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange && _characterControllerScript._change_D != true)
        {
            _haracterHealthScript.Damage(_damage);
        }
        animator.SetBool("IsAttack", false);
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