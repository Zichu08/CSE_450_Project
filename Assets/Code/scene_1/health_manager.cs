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

        livesRemaining = 3;
        startPosition = this.transform.position;
        SetHealth(200);
        RenderHearts();
        alive = true;
    }


    /*
        * Add a specified number of health points to a player's health
        * Parameters - healthPoints: A single unit of health
        */
    public void AddHealth(int healthPoints)
    {
        int healthSum = health + healthPoints;
        if (healthSum < 100)
        {
            health = healthSum;
        }
        else
        {
            health = 100;
        }

        // If for some reason the player is gaining health after being dead, alive is reset as true
        if (!alive)
        {
            alive = true;
        }
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
        if (health <= 0)
        {
            if (livesRemaining > 0)
            {
                livesRemaining--; // Lose a life
                RenderHearts(); // Render hearts
                health_bar.set_health(0); // Set the health bar to zero
                Respawn(); // Reset position and health
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
            health_bar.set_health(health);
        }
    }

    /*
        * Respawn function on losing a heart.
        */

    private void Respawn()
    {
        if (livesRemaining > 0)
        {
            // Set the player's position back to the start position
            transform.position = startPosition;

            // Reset health to full
            SetHealth(200);
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
    }
