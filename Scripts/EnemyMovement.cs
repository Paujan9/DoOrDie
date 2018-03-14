﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {
    public float speed = 1f;
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        nav.speed = speed;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(enemyHealth.currentHealth>0 && playerHealth.currentHealth>0)
        { 
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
