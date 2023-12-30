using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Movement : MonoBehaviour
{
    private Animator animator;
    float dashStart = 0f;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    


    void calculateMovement()
    {   
        float _speed = 5f;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float dashCooldown = 0.5f;
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);    
        transform.Translate(direction * _speed * Time.deltaTime);
        if ((Input.GetKeyDown("space") ||  Input.GetKeyDown(KeyCode.JoystickButton1)) && Time.time > dashCooldown + dashStart)
        {
            print(Time.deltaTime);
            transform.Translate(direction * _speed * 5);
            dashStart = Time.time;

        }

        if(horizontalInput != 0.0 || verticalInput != 0.0)
        {
            animator.SetFloat("Speed", 1);
        }
        if (horizontalInput == 0.0 && verticalInput == 0.0)
        {
            animator.SetFloat("Speed", 0);
        }
    }

   
    // Update is called once per frame
    void Update()
    {

        calculateMovement();
        

    }
}
    
    
 
 