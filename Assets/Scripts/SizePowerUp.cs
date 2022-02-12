using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizePowerUp : MonoBehaviour
{
    
    private SpriteRenderer mySprite;
    private BoxCollider2D myBoxCollider;


    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        
        Invoke("DestroyPrefab", 20f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Ball")
        {
            Debug.Log("Ball entered Trigger");
            
            // SizeUp(Ball.lastHitPlayer);

            StartCoroutine(SizeUp());
        }
    }

    IEnumerator SizeUp()
    {
        GameObject player = Ball.lastHitPlayer;
        mySprite.enabled = false;
        myBoxCollider.enabled = false;
        
        
        //Increase paddle size
        player.GetComponent<Transform>().localScale = player.GetComponent<Transform>().localScale + (Vector3.up * 1.5f);

        //wait 8 seconds (power up lasts only 10 seconds)
        yield return new WaitForSeconds(10f);
        
        //Decrease paddle size
        player.GetComponent<Transform>().localScale = player.GetComponent<Transform>().localScale - (Vector3.up * 1.5f);

    }


    private void DestroyPrefab()
    {
        Destroy(this.gameObject);
    }




}
