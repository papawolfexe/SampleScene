using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{
   public CharacterController controller;
   public CharacterController playerHeight;
   public float gravity = -75f;
   public float jumpHeight = 3f;
   public float normalHeight, crouchHeight;
   
   // Public Variables for Ground check 
   public Transform groundCheck;
   public float groundDistance = 0.4f;
   public LayerMask groundMask;
    
   Vector3 velocity;
   bool isGrounded;
 
 
   void Update()
   {
        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); 
 
        // Player grounded velocity / limiter
        if(isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }

        // Movement on the axis planes
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
 
        Vector3 move = transform.right * x + transform.forward * z;
        
        // player speed
        float speed = 4f; 
       
        // Crouching
        if(Input.GetKey(KeyCode.LeftControl)) 
        {
            speed *= 0.4f;
            playerHeight.height = crouchHeight;
        }else{
            playerHeight.height = normalHeight;
        }
        controller.Move(move * speed * Time.deltaTime);

        // Sprinting
        if(Input.GetKey(KeyCode.LeftShift)) 
        {
            speed *=3f;
        }
        controller.Move(move * speed * Time.deltaTime);

        // Jumping
        if(Input.GetButtonDown("Jump") && isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        // equations for jumping 
        velocity.y += gravity * Time.deltaTime; 
        
        controller.Move(velocity * Time.deltaTime); 
   }
}
