using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_combat : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

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
    }
}
