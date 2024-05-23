using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //public float movementSpeed = 3f;
    //public float detectionRange = 5f;
    //public float attackRange = 1f;

    //public Transform player;
    //private Rigidbody rb;
    //private Animator animator;

    //void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player").transform;
    //    rb = GetComponent<Rigidbody>();
    //    animator = GetComponent<Animator>();
    //}

    //void Update()
    //{
    //    float distanceToPlayer = Vector3.Distance(transform.position, player.position);


    //        if (distanceToPlayer > detectionRange)
    //        {

    //        }
    //        else
    //        {
    //            if (distanceToPlayer <= attackRange)
    //            {
    //                Stop();
    //                Attack();
    //            }
    //            else
    //            {
    //                MoveTowards(player.position);
    //            }
    //        }
    //}

    //void MoveTowards(Vector3 target)
    //{
    //    Vector3 direction = (target - transform.position).normalized;
    //    rb.velocity = new Vector3(direction.x * movementSpeed/*, direction.y * movementSpeed*/, direction.y = 0 * movementSpeed);

    //    animator.SetFloat("MoveX", direction.x);
    //    //animator.SetFloat("MoveY", direction.y);
    //}

    //void Stop()
    //{
    //    rb.velocity = Vector2.zero;
    //    animator.SetFloat("MoveX", 0);
    //    //animator.SetFloat("MoveY", 0);
    //}

    //void Attack()
    //{
    //    Debug.Log("Attack");
    //    animator.SetTrigger("Attack");
    //}

    public Transform player;
    public float moveSpeed = 5f;
    public float attackRange = 2f;
    private float attackCooldown = 2f;
    private float lastAttackTime = -999f;

    public float movementSpeed = 3f;
    public float detectionRange = 5f;

    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent < Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > detectionRange)
        {
            // Логика для дальнего действия
        }
        else
        {
            if (distanceToPlayer <= attackRange && Time.time - lastAttackTime >= attackCooldown)
            {
                Stop();
                Attack();
                lastAttackTime = Time.time;
            }
            else
            {
                MoveTowards(player.position);
            }
        }
    }

    void MoveTowards(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void Stop()
    {
        rb.velocity = Vector2.zero;
        animator.SetFloat("MoveX", 0);
        //animator.SetFloat("MoveY", 0);
    }

    void Attack()
    {
        // Логика атаки
        Debug.Log("Attack");
    }
}