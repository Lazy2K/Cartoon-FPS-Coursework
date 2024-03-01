using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Changeable attributes
    [Header("Movement")]
    public float moveSpeed;
    public float moveSpeedCap;
    public float mouseSensitivity;
    public float groundDrag;
    [Header("Ground Checking")]
    public LayerMask ground;
    public float playerBodyHeight;
    public float groundReach;
    [Header("Player Camera")]
    public Camera viewCamera;

    // Private variables
    private Vector2 cameraRotation;
    private Vector3 moveDirection;
    private bool isGrounded;

    // Private components
    private Rigidbody rb;


    void Start()
    {
        cameraRotation = Vector2.zero;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse movement
        transform.Rotate(0f,Input.GetAxis("Mouse X"),0f);  // Rotate the player object to maintain forwards direction
        cameraRotation.y += Input.GetAxis("Mouse X");      // Update camera Y rotation to maintatin forwards view
        cameraRotation.x += Input.GetAxis("Mouse Y") * -1; // Update camera X rotation based on mouse movement
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, - 80f, 80f); // Clamp X rotation to prevent weird angles
        viewCamera.transform.eulerAngles = (Vector2)cameraRotation * mouseSensitivity; // Apply camera rotations

        // Body movement
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerBodyHeight * 0.5f + groundReach, ground); // Check if the player is touching the ground
        if(isGrounded)
        {
            rb.drag = groundDrag;
        } else
        {
            rb.drag = 0;
        }
    }

    void FixedUpdate()
    {
        // Calculate movement direction based on user input
        moveDirection = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");

        // Apply movement force if player is touching the ground
        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed, ForceMode.Force);
        }

        // Limit player velocity
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.y);
        if(flatVelocity.magnitude > moveSpeedCap)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeedCap;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }

    }
}
