using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace scene_1
{
    public class Boundary : MonoBehaviour
    {
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the collider belongs to the player
            if(collision.gameObject.GetComponent<player_1_controller>())
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);

                Debug.Log("Player hit the boundary!");
            }
        }
    }
}
