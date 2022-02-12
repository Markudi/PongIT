using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAudio : MonoBehaviour
{



    public AudioClip ballHit;

    private AudioSource audioSource;
    private Rigidbody2D ball;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ball = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        var vel = ball.velocity.x;

        if (col.gameObject.name == "Player1" || col.gameObject.name == "Player2")
        {
            this.audioSource.PlayOneShot(ballHit, 1F);
            
        }
        
        
    }
}
