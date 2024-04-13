using System.Collections;
using UnityEngine;

public class player_attack_area : MonoBehaviour {
    // constants
    private int damge = 25;
    
    // events
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.GetComponent<health_manager>() != null && collider.name != name) {
            collider.GetComponent<health_manager>().RemoveHealth(20);
        }
    }
    
    // methods
    private IEnumerator delay(float duration)  {
        yield return new WaitForSeconds(duration);
    }
}
