using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    Animator anim;
    public float speed = 10.0f;
    public float gravity = 20.0f;

    CharacterController controller;

    Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        Time.timeScale = 1;
        anim.SetBool("isDancing", false);
        anim.SetBool("isWalking", false);
    }

    void Update()
    {
        HandleMovement();
        HandleAnimations();
    }

    void HandleMovement()
    {
        // Get input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(x, 0, z);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the character
        controller.Move(moveDirection * Time.deltaTime);
    }

    void HandleAnimations()
    {
        // Check for dancing
        bool isDancing = Input.GetKey(KeyCode.Z);
        bool isWalking = !isDancing && Input.GetKey(KeyCode.W);

        // Set animation states
        anim.SetBool("isDancing", isDancing);
        anim.SetBool("isWalking", isWalking);

        // No need to set Idle explicitly, as Idle is the default state when both are false
    }
}
