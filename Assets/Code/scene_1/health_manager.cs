using UnityEngine;

public class health_manager : MonoBehaviour { 
    // outlets
    public GameObject heartPrefab;
    public Transform heartsContainer; // Reference to the Canvas transform

    // Data members
    public int health = 199;
    public bool alive = true;
    public health_bar_controller health_bar;
    public int livesRemaining;
    public int maxHearts;
    private Vector3 startPosition;


    private CapsuleCollider2D character_collider;
    private Animator animator;
    private Rigidbody2D character;

    /*
        * Set health points to a specified number
        * Parameters - healthPoints: A single unit of health
        */
    public void SetHealth(int healthPoints)
    {
        health = healthPoints;
        health_bar.set_max_health(200);
            
    }

        private void Start() {
            startPosition = this.transform.position; // Save the initial start position
            livesRemaining = 3;
            SetHealth(200);
            RenderHearts();
            alive = true;
            character_collider = GetComponent<CapsuleCollider2D>();
            animator = GetComponent<Animator>();
            character = GetComponent<Rigidbody2D>();
        }


        /*
         * Add a specified number of health points to a player's health
         * Parameters - healthPoints: A single unit of health
         */
        public void AddHealth(int healthPoints)
        {
            // int healthSum = health + healthPoints;
            // if (healthSum < 100)
            // {
            //     health = healthSum;
            // }
            // else
            // {
            //     health = 100;
            // }
            //
            // // If for some reason the player is gaining health after being dead, alive is reset as true
            // if (!alive)
            // {
            //     alive = true;
            // }
            SetHealth(200);
        }

        /*
         * Remove a specified number of health points from a player's health
         * Parameters - healthPoints: A single unit of health
         */

        public void RemoveHealth(int healthPoints)
        {
            if (!alive)
            {
                return; // If the player is already dead, don't process further
            }

            health -= healthPoints;
            if (health <= 0 && livesRemaining > 0)
            {
                animator.SetTrigger("death");
                // Player lost a life but still has more lives remaining
                livesRemaining--; // Lose a life
                
                RenderHearts(); // Render hearts
                health_bar.set_health(0); // Set the health bar to zero
                
                if (livesRemaining > 0)
                {
                // Reset position and health for the next life
                Respawn(); 
                }
                else
                {
                    // No more lives left, the player is now dead
                    alive = false;
                }
            }
            else
            {
                // Update the health bar if health is still above 0
                animator.SetTrigger("hurt");
                health_bar.set_health(health);
            }
        }



        /*
         * Return a player's health
         */
        public int GetHealth()
        {
            return health;
        }

        /*
         * Return if a player is alive or not (has any health)
         */
        public bool GetAlive()
        {
            return alive;
        }



        /*
         * Renders lives remaning
         */
        private void RenderHearts()
        {
            // Clear old hearts
            // Remove all previous hearts
            foreach (Transform child in heartsContainer)
            {
                Destroy(child.gameObject);
            }


            // Calculate the spacing between hearts
            float heartWidth = heartPrefab.GetComponent<RectTransform>().rect.width;
            float spacing = 10f; // Adjust as needed

            float totalWidth = (heartWidth + spacing) * maxHearts;

            // Calculate starting position
            float startX = 0;
            float y = 10;

            // Instantiate hearts
            for (int i = 0; i < maxHearts; i++)
            {
                GameObject heart = Instantiate(heartPrefab, heartsContainer);
                RectTransform heartTransform = heart.GetComponent<RectTransform>();

                // Calculate position for the current heart
                float posX = startX + i * (heartWidth + spacing);
                heartTransform.anchoredPosition = new Vector2(posX, y);

                // Activate/deactivate hearts based on remaining lives
                heart.SetActive(i < livesRemaining);
            }
        }

    // Respawn funcitonality
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player has collided with a boundary
        if (other.CompareTag("Boundary"))
        {
            HandleBoundaryCollision();
        }
    }

    private void HandleBoundaryCollision()
    {
        if (livesRemaining > 0)
        {
            RemoveHealth(health); // This ensures health goes to zero and triggers respawning
        }
        else
        {
            Respawn();
        }
    }

    private void Respawn()
    {

        transform.position = startPosition; // Reset the player's position
        SetHealth(200); // Reset health to full
    }

    //   public void enable_invincible()
    //    {
    //        character.gravityScale = 0;
    //        character_collider.enabled = false;
            
    //    }

    //    public void disable_invincible()
    //    {
            
    //        character_collider.enabled = true;
    //        character.gravityScale = 1.5f;
    //    }
        
        
    }
