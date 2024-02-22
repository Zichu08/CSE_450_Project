using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15.0f;

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
            Debug.Log("Player hit");
            player.GetComponent<health_manager>().RemoveHealth(20); // Remove 20 health from player 2
            Debug.Log("Player health: " + player.GetComponent<health_manager>().GetHealth());
        }
        gameObject.SetActive(false); // Make bullet disappear on impact with enemy
        Destroy(gameObject, 2.0f);
    }
}
