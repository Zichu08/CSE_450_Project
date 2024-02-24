using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_manager : MonoBehaviour
{
    // Data members
    public int health = 100;
    public bool alive = true;
    public health_bar_controller health_bar;

    /*
     * Set health points to a specified number
     * Parameters - healthPoints: A single unit of health
     */
    public void SetHealth(int healthPoints)
    {
        health = healthPoints;
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
        int healthSum = health - healthPoints;
        if (healthSum > -1)
        {
            health = healthSum;
            health_bar.set_health(health);
        }
        else
        {
            health = -1;
            alive = false;
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
