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

    public bool isAlive;

    private AudioSource audioSource;
    public AudioClip nearMissSFX;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        isAlive = true;
        audioSource = gameObject.GetComponent<AudioSource>();
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
        animator.SetBool("isRunning", false);
        animator.SetBool("Dead", true);
        isAlive = false;

    }

    void Patrol()
    {
        // Find patrol routes that arent already being patrolled
        if (animator.GetBool("isRunning"))
        {
            animator.SetBool("isRunning", false);
        } else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void Chase()
    {
        agent.SetDestination(player.transform.position);
        animator.SetBool("Shooting", false);
        if(!animator.GetBool("isRunning"))
        {
            animator.SetBool("isRunning", true);
        }
    }

    void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player.transform);
        animator.SetBool("isRunning", false);
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
        // Need to find a way to direct this towards the player exactly
        RaycastHit hit;
        Vector3 targetVector = muzzelGameObj.transform.forward;
        Vector3 newVecotr = (player.transform.position - muzzelGameObj.transform.position);
        targetVector += transform.up * Random.Range(0.0001f, -0.001f);
        targetVector += transform.right * Random.Range(0.0001f, -0.0001f);
        if (Time.time > timeDelay)
        {
            // Shoot here
            timeDelay = Time.time + (1 / firePerSecond);
            muzzelFlash.Play();
            Debug.DrawLine(muzzelGameObj.transform.position, newVecotr, Color.red, 500f);
            if (Physics.Raycast(muzzelGameObj.transform.position, newVecotr, out hit, 500f))
            {
                Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.gameObject.name == "Player")
                {
                    // Player take damge and assosiated sounds and animations
                    playerScript = hit.collider.gameObject.GetComponent<PlayerInteractions>();
                    audioSource.PlayOneShot(nearMissSFX, 1f);
                    playerScript.TakeDamage();
                } else
                {
                    // Play near miss or bullet impact effects on rock/ground
                    audioSource.PlayOneShot(nearMissSFX, 1f);
                }
            }
        }
    }
}
