using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenericEnemyController : MonoBehaviour
{

    // Enemy variables
    public float startHealth;
    private float health;

    public NavMeshAgent agent;

    // Animation variables
    private Animator animator;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    public void TakeDamge(float amount)
    {

        health = health - amount;
        if (health <= 0f)
        {
            Die();
        } else
        {
            // Enemy is alive
            animator.SetTrigger("TakeDamage");
        }
    }

    void Die()
    {
        animator.SetBool("Dead", true);
    }

    void Patrol()
    {

    }

    void Chase()
    {

    }

    void Attack()
    {

    }
}
