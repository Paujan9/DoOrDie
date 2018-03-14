using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;

    public float flashSpeed = 5f;
    public Color flashColor= new Color(1f, 0f, 0f, 0.1f);

    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;
    bool damaged;
    // Use this for initialization
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        playerAudio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
		if(damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
	}
    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth = currentHealth - amount;
        healthSlider.value = currentHealth;

        if(currentHealth<=0 && !isDead)
        {
            Death();
        }
    }
    void Death()
    {
        isDead = true;

        playerShooting.DisableEffects();
        playerAudio.Play();
        playerMovement.enabled = false;
        playerShooting.enabled = false;
    }
}
