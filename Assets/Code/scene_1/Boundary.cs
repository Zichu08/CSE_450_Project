using System;
using scene_1;
using UnityEngine;

public class Boundary : MonoBehaviour {
        
        // [SerializeField] private player_1_controller player1Controller;
        // [SerializeField] private player_2_controller player2Controller;
        [SerializeField] private player_movement player_controller;
        [SerializeField] private GameObject gameOverText;

        [SerializeField] private GameObject p1WinsText;
        [SerializeField] private GameObject p2WinsText;
        
        public GameObject button;
        public GameObject button2;

        private void Start()
        {
            
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the collider belongs to the player
            if(collision.gameObject.name == "player_1")
            {
                Debug.Log("Player 1 hit the boundary!");
            }
            
            if(collision.gameObject.name == "player_2")
            {
                Debug.Log("Player 2 hit the boundary!");
            }
        }
        
        public void GameOver()
        {
            if (player_controller != null)
            {
                player_controller.disableMovement();
            }
            
            
            

            // if (player2Controller != null) player2Controller.DisableMovement();
            button2.SetActive(true);
            button.SetActive(true);

        }
    }

