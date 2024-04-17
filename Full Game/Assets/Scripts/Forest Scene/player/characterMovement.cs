using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float sprintSpeedIncrement = 20f;

    /*public float groundDrag;*/
    [Header("Gravity")]
    public Vector3 gravity = new Vector3(0, -30f, 0);

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();

        ApplyGravity();

        if (grounded)
        {
            rb.drag = 5f;
        }
        else
        {
            rb.drag = 0f;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed += sprintSpeedIncrement; 
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed -= sprintSpeedIncrement; 
        }

        if (horizontalInput != 0 || verticalInput != 0)
        {
            animator.SetFloat("vertical", verticalInput);
            animator.SetFloat("horizontal", horizontalInput);
        }
        else
        {
            animator.SetFloat("vertical", 0f);
            animator.SetFloat("horizontal", 0f);
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void ApplyGravity()
    {
        if (!grounded)
        {
            rb.AddForce(gravity, ForceMode.Acceleration); 
        }
    }
}
