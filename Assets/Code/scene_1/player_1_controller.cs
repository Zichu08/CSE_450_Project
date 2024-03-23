using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scene_1
{
    public class player_1_controller : MonoBehaviour
    {
        // Outlet
        Rigidbody2D _rigidbody2D;

        // State Tracking
        public int jumpsLeft;

        // State for keping track of player direction
        bool facingRight = true;

        //Animator
        Animator animator;

        public void DisableMovement()
        {
            this.enabled = false; // Disables the script and, consequently, player movement and actions.
        }

        //Gun fire point
        public Transform firePoint;
        public GameObject bulletPrefab;


        // Methods
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            Console.Write(GameObject.Find("player_1").GetComponent<health_manager>().health);
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (this.enabled != false)
            {
                // Move Player Left 
                if (Input.GetKey(KeyCode.A))
                {
                    _rigidbody2D.AddForce(Vector2.left * 18f * Time.deltaTime, ForceMode2D.Impulse);

                    if (facingRight)
                    {
                        //Flip player direction
                        FlipSpriteDirection();
                    }

                }

                // Move Player Right
                if (Input.GetKey(KeyCode.D))
                {
                    _rigidbody2D.AddForce(Vector2.right * 18f * Time.deltaTime, ForceMode2D.Impulse);

                    if (!facingRight)
                    {
                        //Flip player direction
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

                //Punch
                if (Input.GetKeyDown(KeyCode.F))
                {
                }

                //Shoot
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameObject bulletInstance = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                    if (!facingRight) // If we are facing to the left, we want to rotate the bullet 180 degrees
                    {
                        bulletInstance.transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                }

            }

           

            void FlipSpriteDirection()
            {
                //Flips the direction the sprite is facing
                Vector3 currentScale = gameObject.transform.localScale;
                currentScale.x *= -1;
                gameObject.transform.localScale = currentScale;
                facingRight = !facingRight;
            }
            
        }

        private void FixedUpdate()
        {
            float absX = Math.Abs(_rigidbody2D.velocity.x);
            animator.SetFloat("p1Speed", absX);

            if (absX != 0)
            {
                animator.speed = absX / 3f;
            }
            else
            {
                animator.speed = 1f;
            }
        }

        private void OnCollisionStay2D(Collision2D other) {
                // Check that we collided with Ground
                if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
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
    }  
    
}