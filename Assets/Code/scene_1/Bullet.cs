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
        Enemy p2 = collision.gameObject.GetComponent<Enemy>();
        if(p2 != null)
        {
            Debug.Log("Player 2 hit");
            p2.GetComponent<health_manager>().RemoveHealth(20); // Remove 20 health from player 2
            Debug.Log("Player 2 health: " + p2.GetComponent<health_manager>().GetHealth());
        }
        gameObject.SetActive(false); // Make bullet disappear on impact with enemy
        Destroy(gameObject, 2.0f);
    }
}
