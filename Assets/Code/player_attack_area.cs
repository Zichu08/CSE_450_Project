using System;
using System.Collections;
using UnityEngine;

public class player_attack_area : MonoBehaviour {
    // constants
    private int damage = 20;

    // events
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("running");
        if (collider.GetComponent<health_manager>() != null && collider.name != name) {
            collider.GetComponent<health_manager>().RemoveHealth(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        Debug.Log(collider.name);
    }
}
