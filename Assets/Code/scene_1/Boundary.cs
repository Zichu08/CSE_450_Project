using UnityEngine;

public class Boundary : MonoBehaviour {
        
        // [SerializeField] private player_1_controller player1Controller;
        // [SerializeField] private player_2_controller player2Controller;
        [SerializeField] private player_movement player_controller;
        [SerializeField] private GameObject gameOverText;

        [SerializeField] private GameObject p1WinsText;
        [SerializeField] private GameObject p2WinsText;
        
        public GameObject button;

        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            // Check if the collider belongs to the player
            if(collision.gameObject.name == "player_1")
            {
                Debug.Log("Player 1 hit the boundary!");
                GameOver();
                p2WinsText.SetActive(true);
            }
            
            if(collision.gameObject.name == "player_2")
            {
                Debug.Log("Player 2 hit the boundary!");
                GameOver();
                p1WinsText.SetActive(true);
            }
        }
        
        private void GameOver()
        {
            if (player_controller != null)
            {
                player_controller.disableMovement();
            }
            

            // if (player2Controller != null) player2Controller.DisableMovement();
            button.SetActive(true);
        }
    }

