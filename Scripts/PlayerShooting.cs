using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public AudioClip saudymoGarsas;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer gunLine;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
    AudioSource audio;

    private void Start()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
        //AudioSource audio = GetComponent<AudioSource>();
        audio = gameObject.GetComponent<AudioSource>();
        audio.clip = saudymoGarsas;
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer = timer + Time.deltaTime;	

        if(Input.GetButton("Fire1") && timer>= timeBetweenBullets)
        {
            Shoot();
        }
        if(timer>=timeBetweenBullets*effectsDisplayTime)
        {
            DisableEffects();
        }
	}
    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }
    void Shoot()
    {
        audio.Play();
        timer = 0f;

        gunLight.enabled = true;

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if(enemyHealth!=null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);

        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
