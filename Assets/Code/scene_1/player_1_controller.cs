using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scene_1 {
    public class player_1_controller : MonoBehaviour {
        // Outlet
        Rigidbody2D _rigidbody2D;

        // State Tracking
        public int jumpsLeft;

        // State for keping track of player direction
        bool facingRight = true;

        // Reference to player health Object
        //health_manager playerHealth;

        //Fun fire point
        public Transform firePoint;
        public GameObject bulletPrefab;

        // Methods
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            //playerHealth = new health_manager(); // Create the player health manager

            //print(String.Format("Player is alive: {0}\n", playerHealth.GetAlive()));
            //print(String.Format("Player Health is: {0}\n", playerHealth.GetHealth()));

        }

        // Update is called once per frame
        void Update()
        {
            // Move Player Left 
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody2D.AddForce(Vector2.left * 18f * Time.deltaTime, ForceMode2D.Impulse);

                if (facingRight){ //Flip player direction
                    FlipSpriteDirection();
                }
                
            }

            // Move Player Right
            if (Input.GetKey(KeyCode.D))
            {
                _rigidbody2D.AddForce(Vector2.right * 18f * Time.deltaTime, ForceMode2D.Impulse);

                if (!facingRight){ //Flip player direction
                    FlipSpriteDirection();
                }
            }
            
            // Jump
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (jumpsLeft > 0)
                {
                    jumpsLeft--;
                    _rigidbody2D.AddForce(Vector2.up * 8f, ForceMode2D.Impulse);
                }
            }

            //Shoot
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("Player 1 Shoot");
                GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

                //RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right);
                //if (hit) //If we hit the enemy
                //{
                //    Debug.Log("Hit " + hit.collider.gameObject);
                //    player_2_controller enemy = hit.collider.gameObject.GetComponent<player_2_controller>();
                //    if (enemy != null)
                //    {
                //        print("Make player two take damage");
                //    }
                //}
            }

        }

        private void OnCollisionStay2D(Collision2D other)
        {
            // Check that we collided with Ground
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                // Check what is directly below our character's feet
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, 0.7f);
                // Debug.DrawRay(transform.position, Vector2.down * 0.7f); // Visualize Raycast

                // We might have multiple things below out character's feet
                for (int i = 0; i < hits.Length; i++)
                {
                    RaycastHit2D hit = hits[i];

                    // Check that we collided with ground below our feet
                    if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                    {
                        // Reset jump count
                        jumpsLeft = 2;
                    }
                }
            }
        }

        private void FlipSpriteDirection(){ //Flips the direction the sprite is facing
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;
            facingRight = !facingRight;
            print("Player is facing right: " + facingRight);
        }

    }
}