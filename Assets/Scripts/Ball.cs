using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    
    //Scenes
    public string sceneToLoad;


    //Ball
    public float speed = 6f;
    public float speedMultiplier = 1.35f;
    private Vector2 lastVelocity;
    private Rigidbody2D rb;

    
    //Score
    public int scoreToWin = 5;
    public TextMeshProUGUI Player1ScoreText;
    public TextMeshProUGUI Player2ScoreText;
    private int Player2Score = 0;
    private int Player1Score = 0;
    
    
    //powerUp
    public static GameObject lastHitPlayer;


    
    void Start()
    {
        //Ball
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        startingLaunch();
        
        //Text
        Player1ScoreText.text = "0";
        Player2ScoreText.text = "0";
    }
    


    void Update()
    {
        checkScore();
    }
    
    
    float hitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        return (ballPos.y - paddlePos.y) / paddleHeight;
    }
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Paddle"))
        {
            float x;

            if (col.gameObject.name == "Player1")
            {
                x = 1;
            }
            else
            {
                x = -1;
            }

            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            
            Vector2 dir = new Vector2(x, y).normalized;

            GetComponent<Rigidbody2D>().velocity = dir * speed;

            //Speed increase
            speed *= speedMultiplier;
            // Debug.Log(GetComponent<Rigidbody2D>().velocity);
            
            
            //keep track of last hit player for power ups
            lastHitPlayer = col.gameObject;
            
            // Debug.Log(lastHitPlayer);
            // Debug.Log(lastHitPlayer.GetType());
        }
    }

    
    
    
    //Scoring a goal 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player1Goal"))
        {
            Player1Score++;

            Player1ScoreText.text = Player1Score.ToString();

            //Change score text color to green briefly
            Player1ScoreText.GetComponent<TextMeshProUGUI>().color = new Color32(27, 236, 26, 100);
            Invoke("ChangeBackToNormalColor", 1f);
            
            
            //Delay of 2 seconds before launch
            Invoke("LaunchLeft", 2);

        }else if (col.gameObject.CompareTag("Player2Goal"))
        {
            

            Player2Score++;
            
            Player2ScoreText.text = Player2Score.ToString();
            
            //Change score text color to green briefly
            Player2ScoreText.GetComponent<TextMeshProUGUI>().color = new Color32(27, 236, 26, 100);
            Invoke("ChangeBackToNormalColor", 1f);
            
            
            
            //Delay of 2 seconds before launch
            Invoke("LaunchRight", 2);
            
        }
    }

    private void ChangeBackToNormalColor()
    {
        Player1ScoreText.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 100);
        Player2ScoreText.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 100);
        
    }
    
    
    
    
    private void startingLaunch()
    {
        transform.position = new Vector3(0, 0, 0);
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }


    

    private void LaunchLeft()
    {
        speed = 4f;
        float x = -1f;
        float y = Random.Range(-1f, 1f);
        rb.velocity = new Vector2(speed * x, speed * y);
        transform.position = new Vector3(0, 0, 0);
        this.gameObject.GetComponent<TrailRenderer>().Clear();
    }
    
    private void LaunchRight()
    {
        speed = 4f;
        float x = 1f;
        float y = Random.Range(-1f, 1f);
        rb.velocity = new Vector2(speed * x, speed * y);
        transform.position = new Vector3(0, 0, 0);
        this.gameObject.GetComponent<TrailRenderer>().Clear();
    }


    //check winning score condition
    private void checkScore()
    {
        //Game over 
        if (Player1Score >= scoreToWin)
        {
            Player1Score = 0;
            Player2Score = 0;

            Player1ScoreText.text = Player1Score.ToString();
            Player2ScoreText.text = Player2Score.ToString();

            Winner.winner = "Player 1 Wins!";

            WinnerScreen();

            // Debug.Log("Game Over!");
            // Debug.Log("Player 1 Wins!");
        }
        else if (Player2Score >= scoreToWin)
        {
            Player1Score = 0;

            Player2Score = 0;

            Player1ScoreText.text = Player1Score.ToString();

            Player2ScoreText.text = Player2Score.ToString();

            Winner.winner = "Player 2 Wins!";

            WinnerScreen();

            // Debug.Log("Game Over!");
            // Debug.Log("Player 2 Wins!");
        }
    }
    
    
    public void WinnerScreen()
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
    
    
    
}
