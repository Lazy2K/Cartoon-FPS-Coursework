using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ToonTyrant : MonoBehaviour
{
    // Internal variables
    public float startHealth;
    private float health;
    public bool isAlive;

    // Pathfinding variables
    public float sightRange;
    private bool playerInSight;
    private GameObject player;
    public LayerMask whatIsPlayer;
    public NavMeshAgent agent;
    private Vector3 walkPoint;

    // Animation variables
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if(playerInSight && health > 0)
        {
            Run();
        }
    }

    void Run()
    {
        Vector3 dirToPlayer = transfrom.position - player.transfrom.position;
        Vector3 newPos = transfrom.position + dirToPlayer;
        agent.SetDestination(newPos);
    }

    void Die()
    {
        isAlive = false;
        agent.SetDestination(transform.position);
    }
}
