using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_1: MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask playerLayers;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Attack();
        } 
    }

    void Attack()
    {
        // Play an attack animation
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        // Diebug.Log("running");
        foreach (Collider2D player in hitEnemies)
        {
             //Debug.Log("running");
            if (player.name == "player_2")
            {
               // Debug.Log(enemy.name);

                //Debug.Log("We hit" + enemy.name);
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