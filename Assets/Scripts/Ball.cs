using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public float speedMultiplier = 1.2f;
    public Rigidbody2D rb;
    
    public TextMeshProUGUI Player1ScoreText;
    public TextMeshProUGUI Player2ScoreText;
    private int Player2Score = 0;
    private int Player1Score = 0;

    private Vector2 lastVelocity;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player1ScoreText.text = "0";
        Player2ScoreText.text = "0";
        startingLaunch();

    }

    // Update is called once per frame
    void Update()
    {
        checkScore();
    }
    
    
    private void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }
    
    
    private void startingLaunch()
    {
        transform.position = new Vector3(0, 0, 0);
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        Vector2 newVelocity = Vector2.Reflect(lastVelocity, col.contacts[0].normal);
        rb.velocity = newVelocity;
        
        
        //speed increase everytime hits a paddle
        if (col.gameObject.CompareTag("Paddle"))
        {
            rb.velocity = speedMultiplier * newVelocity;
        }
    }

    //Scoring a goal 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player1Goal"))
        {
            Player1Score++;
            Player1ScoreText.text = Player1Score.ToString();
            Debug.Log("Player 1 Scored. Player1 currently has " + Player1Score + " Points vs Player2's " + Player2Score + " points");

            
            
            //Delay of 2 seconds before launch
            Invoke("LaunchLeft", 2);

        }else if (col.gameObject.CompareTag("Player2Goal"))
        {
            Player2Score++;
            Player2ScoreText.text = Player2Score.ToString();
            Debug.Log("Player 2 Scored. Player2 currently has " + Player2Score + " Points vs Player1's " + Player1Score + " points");

            //Delay of 2 seconds before launch
            Invoke("LaunchRight", 2);

        }
    }
    
    
    private void LaunchLeft()
    {

        float x = -1f;
        float y = Random.Range(-1f, 1f);
        rb.velocity = new Vector2(speed * x, speed * y);
        transform.position = new Vector3(0, 0, 0);

    }
    
    private void LaunchRight()
    {
        float x = 1f;
        float y = Random.Range(-1f, 1f);
        rb.velocity = new Vector2(speed * x, speed * y);
        transform.position = new Vector3(0, 0, 0);

    }


    
    //check winning score condition
    private void checkScore()
    {
        //Game over 
        if (Player1Score >= 11)
        {
            Player1Score = 0;
            Player2Score = 0;
            Player1ScoreText.text = Player1Score.ToString();
            Player2ScoreText.text = Player2Score.ToString();
            Debug.Log("Game Over!");
            Debug.Log("Player1 Wins!");
        }else if (Player2Score >= 11)
        {
            Player1Score = 0;
            Player2Score = 0;
            Player1ScoreText.text = Player1Score.ToString();
            Player2ScoreText.text = Player2Score.ToString();
            Debug.Log("Game Over!");
            Debug.Log("Player2 Wins!");
        }
    }
    
    
    
}
