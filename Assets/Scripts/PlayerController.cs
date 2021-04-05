using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private float gravity = -15.81f;
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private float jumpForce = 3.0f;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float groundDistnace = 0.4f;
    [SerializeField]
    private LayerMask groundMask;

    public Animator animator;

    bool isGrounded = false;
    Vector3 verticalVel;
    Vector3 horizontalVel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

    }

    void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        horizontalVel = transform.forward * z + transform.right * x;
        verticalVel.y += gravity * Time.deltaTime;

        if (isGrounded && verticalVel.y < 0)
        {
            verticalVel.y = -2f;

        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            verticalVel.y += Mathf.Sqrt(jumpForce * -2.0f * gravity);
        }
        
    }

    void FixedUpdate() 
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistnace, groundMask);

        animator.SetBool("Grounded", isGrounded);
        

        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Swing") && horizontalVel != Vector3.zero)
        {
            controller.Move(horizontalVel * speed * Time.deltaTime);
            animator.SetFloat("MoveSpeed", horizontalVel.magnitude);
        }
        

        controller.Move(verticalVel * Time.deltaTime);
    }
}
