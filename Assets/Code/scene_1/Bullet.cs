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
        scene_1.player_2_controller playerObject = collision.gameObject.GetComponent<scene_1.player_2_controller>();
        if (player != null)
        {
            int damageAmount = 20;
            // if (playerObject.GetActivePowerup() == "BULLET_POWERUP")
            // {
            //     Debug.Log("Bullet powerup damage increase");
            //     damageAmount = 40;
            // }

            player.RemoveHealth(damageAmount); // Remove 20 health from player 2
   
        }
        gameObject.SetActive(false); // Make bullet disappear on impact with enemy
        Destroy(gameObject, 2.0f);
    }
}
