using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class player_movement : MonoBehaviour {
    // outlets
    Rigidbody2D rigid_body_2D;
    public GameObject health_bar_canvas;
    
    // configuration
    public KeyCode jump;
    public KeyCode move_left;
    public KeyCode move_right;
    
    // state tracking
    public int jumps_left;
    private bool sprite_facing_right;
    
    //  constants
    private int max_jumps_left = 2;
    
    // animator
    private Animator animator;
    
    // event functions
    void Start() {
        rigid_body_2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health_bar_canvas = transform.GetChild(3).gameObject;
        jumps_left = 2;
    }

    void Update() {
        if (Input.GetKey(move_left)) {
            rigid_body_2D.AddForce(Vector2.left * 18f * Time.deltaTime, ForceMode2D.Impulse);
            if (sprite_facing_right) {
                flipSpriteDirection();
            }
        }
        
        if (Input.GetKey(move_right)) {
            rigid_body_2D.AddForce(Vector2.right * 18f * Time.deltaTime, ForceMode2D.Impulse);
            if (!sprite_facing_right) {
                flipSpriteDirection();
            }
        }
        if (Input.GetKeyDown(jump)) {
            jumpFunc();
        }
        animator.SetInteger("jumps_left", jumps_left);
        
    }
    
    private void OnCollisionStay2D(Collision2D other) {
        // check that we collided with Ground layer
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground")) {
            // check what is directly below our character's feet
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down, 1f);
            
            // we might have multiple things below our character's feet
            for (int i = 0; i < hits.Length; i++) {
                RaycastHit2D hit = hits[i];
                // check that we collided with ground below our feet
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground")) {
                    // reset jump count
                    jumps_left = max_jumps_left;
                }
            }
        }
    }
    
    private void FixedUpdate() {
        float absX = Math.Abs(rigid_body_2D.velocity.x);
        float absY = Math.Abs(rigid_body_2D.velocity.y);
        animator.SetFloat("speed", absX);
        if(absY != 0) {
            animator.speed = 0;
        }
        if (absX != 0 && absY == 0) {
            animator.speed = absX / 3f;
        } else {
            animator.speed = 1f;
        }
    }
    
    // methods
    void jumpFunc() {
        if (jumps_left > 0) {
            jumps_left -=  1;
            rigid_body_2D.AddForce(Vector2.up * 8f, ForceMode2D.Impulse);
        }
    }
    
    void flipSpriteDirection() {
        Vector3 new_scale = gameObject.transform.localScale;
        new_scale.x *= -1;
        gameObject.transform.localScale = new_scale;
        sprite_facing_right = !sprite_facing_right;
        health_bar_canvas.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
    }
}
