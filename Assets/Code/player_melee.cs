using UnityEngine;

public class player_melee : MonoBehaviour {
    // outlets
    private GameObject attack_area_1 = default;
    private GameObject attack_area_2 = default;
    private GameObject attack_area_3 = default;
    
    // state tracking
    private bool attacking = false;
    private float timer = 0f;
    
    // configuration
    public KeyCode attack_1;
    public KeyCode attack_2;
    public KeyCode attack_3;
    
    // constants
    private float time_to_attack = 0.25f;
    
    // animator
    public Animator animator;

    private void Start() {
        attack_area_1 = transform.GetChild(0).gameObject;
        attack_area_2 = transform.GetChild(1).gameObject;
        attack_area_3 = transform.GetChild(2).gameObject;
        attack_area_1.SetActive(false);
        attack_area_2.SetActive(false);
        attack_area_3.SetActive(false);
    }

    private void Update() {
        if (Input.GetKey(attack_1)) {
            animator.SetTrigger("attack_1");
            attack1();
        }
        if (Input.GetKey(attack_2)) {
            animator.SetTrigger("attack_2");
            attack2();
        }
        if (Input.GetKey(attack_3)) {
            animator.SetTrigger("attack_3");
            attack3();
        }

        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= time_to_attack) {
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
        attack_area_1.SetActive(attacking);
    }
    
    void attack2() {
        Debug.Log("running");
        attacking = true;
        attack_area_2.SetActive(attacking);
    }
    
    void attack3()
    {
        attacking = true;
        attack_area_3.SetActive(attacking);
    }
}


    

