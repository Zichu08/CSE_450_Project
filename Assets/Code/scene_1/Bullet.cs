using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15.0f;
    
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   // Bullet direction is handled in player class
        transform.position += transform.right * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health_manager player = collision.gameObject.GetComponent<health_manager>();
        
        if(player != null)
        {
            player.RemoveHealth(20); // Remove 20 health from player 2
            
            
        }
        gameObject.SetActive(false); // Make bullet disappear on impact with enemy
        Destroy(gameObject, 2.0f);
    }
}
