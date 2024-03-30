using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_manager : MonoBehaviour
{
    // Data members
    public int health = 199;
    public bool alive = true;
    public health_bar_controller health_bar;
    public int livesRemaining = 3;

    /*
     * Set health points to a specified number
     * Parameters - healthPoints: A single unit of health
     */
    public void SetHealth(int healthPoints)
    {
        health = healthPoints;
        health_bar.set_max_health(200);
    }

    private void Start()
    {
        livesRemaining = 3;
        SetHealth(200);
        
    }

    
    /*
     * Add a specified number of health points to a player's health
     * Parameters - healthPoints: A single unit of health
     */
    public void AddHealth(int healthPoints) {
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
            return; // If the player is already dead, don't process further

        health -= healthPoints;
        if (health <= 0 && livesRemaining > 0)
        {
            // Player lost a life but still has more lives remaining
            livesRemaining--; // Lose a life
            health_bar.set_health(0); // Set the health bar to zero

            if (livesRemaining > 0)
            {
                // Reset health for the next life
                SetHealth(200);
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

}
