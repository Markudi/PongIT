using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallAudio : MonoBehaviour
{



    public AudioClip ballHit;
    public AudioClip fasterBall;

    private AudioSource audioSource;
    public Rigidbody2D ball;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ball = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        float ballSpeed = this.gameObject.GetComponent<Ball>().speed;
        // Debug.Log(ballSpeed);

        if (col.gameObject.name == "Player1" || col.gameObject.name == "Player2")
        {


            //If ball is going fast, play woosh sound else play normal pong sound
            if (ballSpeed >= 10)
            {
                this.audioSource.PlayOneShot(fasterBall, 0.5F);
            }
            else
            {
                this.audioSource.PlayOneShot(ballHit, 1F);
            }

        }


    }
}
