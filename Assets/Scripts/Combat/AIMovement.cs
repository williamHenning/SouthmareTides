using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private float gravity = -15.81f;
    [SerializeField]
    private float speed = 2.0f;
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
    }

    public void HandleMovement(Vector3 target, bool jump, float attackRange)
    {
        transform.LookAt(target);
        //transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
        if(Vector3.Distance(target, transform.position) > attackRange)
        {
            horizontalVel = transform.forward;
        }
        else
        {
            horizontalVel = Vector3.zero;
        }
        
        verticalVel.y += gravity * Time.deltaTime;

        if (isGrounded && verticalVel.y < 0)
        {
            verticalVel.y = -2f;

        }

        if (jump && isGrounded)
        {
            verticalVel.y += Mathf.Sqrt(jumpForce * -2.0f * gravity);
        }

    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistnace, groundMask);

        animator.SetBool("Grounded", isGrounded);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Movement") && horizontalVel != Vector3.zero)
        {
            controller.Move(horizontalVel * speed * Time.deltaTime);
            animator.SetFloat("MoveSpeed", horizontalVel.magnitude);
        }


        controller.Move(verticalVel * Time.deltaTime);
    }

}
