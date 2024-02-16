using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
namespace scene_1 {
    public class player_2_controller : MonoBehaviour {
        // Outlet
        Rigidbody2D _rigidbody2D;

        // State Tracking
        public int jumpsLeft;

        // State for keping track of player direction
        bool facingRight = true;
        
        public void DisableMovement()
        {
            this.enabled = false; // Disables the script and, consequently, player movement and actions.
        }

        //health_manager playerHealth;


        // Methods
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            //playerHealth = new health_manager(); // Create the player health manager
            //Debug.Log("Player 2 Health: " + playerHealth.GetHealth());
        }

        // Update is called once per frame
        void Update()
        {
            if (this.enabled != false)
            {
                // Move Player Left 
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    _rigidbody2D.AddForce(Vector2.left * 18f * Time.deltaTime, ForceMode2D.Impulse);

                    if (facingRight)
                    {
                        //Flip player direction
                        FlipSpriteDirection();
                    }
                }

                // Move Player Right
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    _rigidbody2D.AddForce(Vector2.right * 18f * Time.deltaTime, ForceMode2D.Impulse);

                    if (!facingRight)
                    {
                        //Flip player direction
                        FlipSpriteDirection();
                    }
                }

                // Jump
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    if (jumpsLeft > 0)
                    {
                        jumpsLeft--;
                        _rigidbody2D.AddForce(Vector2.up * 8f, ForceMode2D.Impulse);
                    }
                }

                //Punch
                if (Input.GetKeyDown(KeyCode.L))
                {
                    print("Player 2 Shoot");
                    /**
                     * Figure out shoot mechanics
                     * Need way to switch to shoot player model (Shoot bullet)
                     * Need a way to damage the player in front of the player punching (within a certain range)
                     */
                }
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

        private void FlipSpriteDirection()
        { //Flips the direction the sprite is facing
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;
            facingRight = !facingRight;
            print("Player is facing right: " + facingRight);
        }
    }
}