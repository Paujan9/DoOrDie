using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public GameObject [] enemies;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	void Spawn()
    {
        if(playerHealth.currentHealth<=0f)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int enemyIndex = Random.Range(0, enemies.Length);

        Instantiate(enemies[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
