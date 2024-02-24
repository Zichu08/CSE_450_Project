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
        Enemy player = collision.gameObject.GetComponent<Enemy>();
        
        if(player != null)
        {
            player.GetComponent<health_manager>().RemoveHealth(20); // Remove 20 health from player 2
            
            
        }
        gameObject.SetActive(false); // Make bullet disappear on impact with enemy
        Destroy(gameObject, 2.0f);
    }
}
