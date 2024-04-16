using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class player_melee : MonoBehaviour {
    // outlets
    private GameObject attack_area_1;
    private GameObject attack_area_2;
    private GameObject attack_area_3;
    public Animator animator;
    private CapsuleCollider2D character;
    
    // state tracking
    private bool attacking;
    private float timer;
    private bool animation_finished = true;
    
    // configuration
    public KeyCode attack_1;
    public KeyCode attack_2;
    public KeyCode attack_3;
    
    // constants
    private float attack_duration = 0.25f;

    private void Start() {
        attack_area_1 = transform.GetChild(0).gameObject;
        attack_area_2 = transform.GetChild(1).gameObject;
        attack_area_3 = transform.GetChild(2).gameObject;
        attack_area_1.SetActive(false);
        attack_area_2.SetActive(false);
        attack_area_3.SetActive(false);
        character = GetComponent<CapsuleCollider2D>();
        Debug.Log(this.name);
    }

    private void Update() {
        if (Input.GetKey(attack_1) && animation_finished) {
            animator.SetTrigger("attack_1");
            animation_finished = false;
            attack1();
        }
        if (Input.GetKey(attack_2) && animation_finished) {
            animator.SetTrigger("attack_2");
            animation_finished = false;
            attack2();
        }
        if (Input.GetKey(attack_3) && animation_finished) {
            animator.SetTrigger("attack_3");
            animation_finished = false;
            attack3();
        }

        if (attacking) {
            timer += Time.deltaTime;
            if (timer >= attack_duration) {
                timer = 0;
                attacking = false;
                attack_area_1.SetActive(attacking);
                attack_area_2.SetActive(attacking);
                attack_area_3.SetActive(attacking);
            }
        }
    }
    
    // methods
    void attack1() {
        attacking = true;
        character.enabled = false;
        character.enabled = true;
        attack_area_1.SetActive(attacking);
    }
    
    void attack2() {
        attacking = true;
        character.enabled = false;
        character.enabled = true;
        attack_area_2.SetActive(attacking);
    }
    
    void attack3() {
        attacking = true;
        character.enabled = false;
        character.enabled = true;
        attack_area_3.SetActive(attacking);
    }

    public void set_animation_finished() {
        animation_finished = true;
    }
}


    

