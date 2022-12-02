using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Camera cam;

    [SerializeField] Vector3 velocity;
    bool isGrounded;

    [SerializeField] private Animator animator;
    [SerializeField] private float immuneCounter = 5;

    [SerializeField] private GameObject DiePanel;
    public int lives = 5;

    void Start()
    {
        animator.SetBool("isAlive", true);   
    }

    void Update()
    {
        Walk();
        immuneCounter -= Time.deltaTime;
    }

    private void Walk()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    public void TakeDamage()
    {
        if(lives == 4)
        {

        }
        else if(lives == 3)
        {

        }
        else if(lives == 2)
        {

        }
        else if(lives == 1)
        {

        }

        if (immuneCounter < 0 && lives > 0)
        {
            lives--;
            immuneCounter = 5;
        }
        else if (lives <= 0)
        {
            animator.SetBool("isAlive", false);
            DiePanel.SetActive(true);
            MapCheckpoints.instance.isGameOver(true);
        }
    }
}