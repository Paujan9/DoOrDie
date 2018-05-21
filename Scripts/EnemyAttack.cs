using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    Animator anim;

    bool playerInRange;
    float timer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==player)
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer = timer + Time.deltaTime;
        if(anim!=null)
            anim.SetBool("IsAttacking", false);
        if (timer>=timeBetweenAttacks&&playerInRange&&enemyHealth.currentHealth>0)
        {
            if (anim != null)
                anim.SetBool("IsAttacking", true);
            Attack();
            
        }
	}
    void Attack()
    {
        
        timer = 0f;
        if(playerHealth.currentHealth>=0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
