using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

 public Rigidbody rb;

   public float forwardForce = 50f;
    public float sidewaysForce = 50f;
     public float upwardsForce = 400f;


   

    public bool moving_Left;
    public bool moving_Right;
    public bool moving_Forward;
    public bool moving_Back;
    

    void Update()
    {

     
        //Detects which way the player is moving based on which key is pressed
       
        //if the player presses the "d" key down, it will set moving_Right to true and the opposite to false
        if (Input.GetKeyDown("d"))
        {
            moving_Right = true;
            moving_Left = false;
        }
        //if they release the "d" key, it will set moving_Right back to false
        if (Input.GetKeyUp("d"))
        {
           moving_Right = false;
        }



            if (Input.GetKeyDown("a"))
            {
                moving_Right = false;
                moving_Left = true;
            }

            if (Input.GetKeyUp("a"))
            {
                moving_Left = false;
            }



                if (Input.GetKeyDown("w"))
                {
                    moving_Forward = true;
                    moving_Back = false;
                }

                if (Input.GetKeyUp("w"))
                {
                    moving_Forward = false;
                }

                        if (Input.GetKeyDown("s"))
                        {
                            moving_Back = true;
                            moving_Forward = false;
                        }
                        if (Input.GetKeyUp("s")) 
                        {
                            moving_Back = false;
                        }



                        //calls the Jump function
                               if (Input.GetKey("space"))
                                {
                                    Jump();
                                }


    }

    //Always use Fixed update when working with movement
    private void FixedUpdate()
    {
        rb.AddForce(0,-20000 * Time.deltaTime ,0, ForceMode.Force);
        //Determines if any of the booleans are true and creates movements based on that


        if (moving_Forward == true)
        {
            rb.AddForce(0, 0, -forwardForce* Time.deltaTime, ForceMode.VelocityChange);
        }


            if (moving_Back == true)
            {
                rb.AddForce(0, 0, forwardForce * Time.deltaTime, ForceMode.VelocityChange);
            }


                if (moving_Right == true)
                {
                    rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }


                    if (moving_Left == true)
                    {
                        rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                    }


    }

    void Jump()
    {
        rb.AddForce(0, upwardsForce, 0, ForceMode.Impulse);
    }
    //adds an impulse force directly upwards on the object

}
