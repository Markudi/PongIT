using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    
    public float movementPerSecond = 30f;
    

    
    private void FixedUpdate()
    {
        //Grab RigidBody component
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();

        //If the name of the game object is "player1" use the vertical input else use vertical2 for player2
        if (rbody.gameObject.name == "Player1")
        {
            float movementAxis = Input.GetAxis("Vertical");
            Vector2 force = Vector2.up * movementAxis * movementPerSecond * Time.deltaTime;
            rbody.AddForce(force , ForceMode2D.Impulse);
            
        }else if (rbody.gameObject.name == "Player2")
        {
            float movementAxis2 = Input.GetAxis("Vertical2");
            Vector2 force2 = Vector2.up * movementAxis2 * movementPerSecond * Time.deltaTime;
            rbody.AddForce(force2 , ForceMode2D.Impulse);
        }
    }
    
    
    //testing gitHub commit

    //testing git
    //I hope i'm doing this right
    
}
