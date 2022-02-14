using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    
    public float movementPerSecond = 10f;
    
    private Rigidbody2D rBodyPlayer;

    private void Start()
    {
        rBodyPlayer = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        
        if (rBodyPlayer.gameObject.name == "Player1")
        {
            float movementAxis = Input.GetAxis("Vertical");
            
            Vector2 force = Vector2.up * movementAxis * movementPerSecond * Time.deltaTime;
            
            rBodyPlayer.AddRelativeForce(force , ForceMode2D.Impulse);
            
        }else if (rBodyPlayer.gameObject.name == "Player2")
        {
            float movementAxis = Input.GetAxis("Vertical2");
            
            Vector2 force = Vector2.up * movementAxis * movementPerSecond * Time.deltaTime;
            
            rBodyPlayer.AddRelativeForce(force , ForceMode2D.Impulse);
        }
    }

}
