using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -5f;
    public float jumpStrength = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public AudioSource footsteps;
    public AudioSource jump;
    public float x;
    Vector3 velocity;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2") )
        {
            footsteps.pitch = 0.6f;
            jump.pitch = 0.3f;

        }
        else
        {
            jump.pitch = 1f;
            footsteps.pitch = Random.Range(1.4f, 2.5f);
        }

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) )&& isGrounded)
        {
            if (!footsteps.isPlaying)
            {
                footsteps.Play(0);
            }
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y< 0)
        {

            x = Input.GetAxis("Horizontal");
            velocity.y = -2f;
        }

        /*if (!isGrounded)
        {
            x = 0;
        }*/



        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right* x+ transform.forward* z;

        controller.Move(move* speed* Time.deltaTime);

        if(Input.GetKey("space") && isGrounded)
        {
            jump.Play(0);
            velocity.y = Mathf.Sqrt(jumpStrength * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
