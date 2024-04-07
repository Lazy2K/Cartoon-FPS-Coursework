using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Hit", true);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Hit", false);
        }
    }
}
