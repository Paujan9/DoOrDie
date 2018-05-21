using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    BoxCollider boxCollider;
    bool isDead;
    bool isSinking;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
        if(isSinking)
        { 
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }
    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;
        currentHealth = currentHealth - amount;
        if(currentHealth<=0)
        {
            Death();
        }
    }
    void Death()
    {
        isDead = true;
        boxCollider.isTrigger = true;
        StartSinking();
    }
    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        ScoreManager.score = ScoreManager.score + scoreValue;
        Destroy(gameObject, 2f);
    }
}
