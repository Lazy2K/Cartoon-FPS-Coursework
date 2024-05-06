using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GenericEnemyController : MonoBehaviour
{

    // Enemy variables
    public float startHealth;
    private float health;

    public float sightRange;
    public float attackRange;

    public ParticleSystem muzzelFlash;

    public NavMeshAgent agent;

    // Animation variables
    private Animator animator;

    private GameObject player;
    public LayerMask whatIsPlayer;

    private bool playerInSight, playerInAttack;

    private Vector3 walkPoint;

    private float timeDelay;
    public float firePerSecond;

    public GameObject muzzelGameObj;

    private PlayerInteractions playerScript;

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
        playerInSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttack = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSight && !playerInAttack && health > 0) Patrol();
        if (playerInSight && !playerInAttack && health > 0) Chase();
        if (playerInSight && playerInAttack && health > 0) Attack();
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
        agent.SetDestination(transform.position);
        animator.SetBool("Shooting", false);
        animator.SetBool("Dead", true);

    }

    void Patrol()
    {
        // Find patrol routes that arent already being patrolled
    }

    void Chase()
    {
        agent.SetDestination(player.transform.position);
    }

    void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player.transform);

        animator.SetBool("Shooting", true);
        Shoot();

        // Attack the player
    }

    void SearchWalkPoint()
    {
        // Function for finding patrol paths
    }

    void Shoot()
    {
        RaycastHit hit;
        Vector3 targetVector = muzzelGameObj.transform.forward;
        targetVector += transform.up * Random.Range(0.01f, -0.1f);
        targetVector += transform.right * Random.Range(0.01f, -0.01f);
        if (Time.time > timeDelay)
        {
            // Shoot here
            timeDelay = Time.time + (1 / firePerSecond);
            muzzelFlash.Play();
            if (Physics.Raycast(muzzelGameObj.transform.position, targetVector, out hit, 500f))
            {
                Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.gameObject.name == "Player")
                {
                    // Player take damge and assosiated sounds and animations
                    playerScript = hit.collider.gameObject.GetComponent<PlayerInteractions>();
                    playerScript.TakeDamage();
                } else
                {
                    // Play near miss or bullet impact effects on rock/ground
                }
            }
        }
    }
}
