using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericEnemyController : MonoBehaviour
{

    // Enemy variables
    public float startHealth;
    private float health;

    // Animation variables
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

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
