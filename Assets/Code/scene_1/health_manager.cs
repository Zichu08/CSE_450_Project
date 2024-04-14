using UnityEngine;

public class health_manager : MonoBehaviour
{
    // Outlets
    public GameObject heartPrefab;
    public Transform heartsContainer; // Reference to the Canvas transform
    public health_bar_controller health_bar;

    // Data members
    public int health = 200;
    public bool alive = true;
    public int livesRemaining;
    public int maxHearts;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = this.transform.position; // Save the initial start position
        livesRemaining = 3; // Initial number of lives
        SetHealth(200); // Set initial health
        RenderHearts(); // Visualize hearts
        alive = true;
    }

    public void SetHealth(int healthPoints)
    {
        health = healthPoints;
        health_bar.set_max_health(200);
    }

    public void AddHealth(int healthPoints)
    {
        health = Mathf.Min(health + healthPoints, 200); // Ensure health does not exceed 200
        if (!alive)
        {
            alive = true;
        }
    }

    public void RemoveHealth(int healthPoints)
    {
        if (!alive)
        {
            return; // If the player is already dead, don't process further
        }

        health -= healthPoints;
        if (health <= 0)
        {
            livesRemaining--; // Lose a life
            RenderHearts(); // Update hearts display
            health_bar.set_health(0); // Set health bar to zero

            if (livesRemaining > 0)
            {
                Respawn(); // Reset position and health
            }
            else
            {
                alive = false; // No more lives left
            }
        }
        else
        {
            health_bar.set_health(health); // Update the health bar if health is still above 0
        }
    }

    private void OnTriggerEnter(Collider other)
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
            alive = false;
        }
    }

    private void Respawn()
    {
        transform.position = startPosition; // Reset the player's position
        SetHealth(200); // Reset health to full
    }

    private void RenderHearts()
    {
        foreach (Transform child in heartsContainer)
        {
            Destroy(child.gameObject);
        }

        float heartWidth = heartPrefab.GetComponent<RectTransform>().rect.width;
        float spacing = 10f; // Space between hearts

        for (int i = 0; i < maxHearts; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartsContainer);
            RectTransform heartTransform = heart.GetComponent<RectTransform>();
            heartTransform.anchoredPosition = new Vector2(i * (heartWidth + spacing), 10);
            heart.SetActive(i < livesRemaining);
        }
    }
}
