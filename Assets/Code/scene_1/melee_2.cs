using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_2: MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Attack();
        } 
    }

    void Attack()
    {
        // Play an attack animation
        animator.SetTrigger("Attack");
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        foreach (Collider2D player in hitEnemies)
        {
            if (player.name == "player_1")
            {
                Debug.Log(player.name);

                Debug.Log("We hit" + player.name);
                player.GetComponent<health_manager>().RemoveHealth(20);

            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        
    }
}