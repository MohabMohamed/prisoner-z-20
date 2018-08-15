﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RangedWeapon : MonoBehaviour {

    public int PistolDamage;

    [Space]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject muzzleFlash;
    public float bulletSpeed;
    public GameObject flash;

    public float cooldownTime;
    float cooldownTemp;


    private HealthSystem health;

	void Start () {
        health = gameObject.GetComponent<HealthSystem>();
	}
	

	void Update () {
        cooldownTemp += Time.deltaTime;
        if ( !health.IsDead() && Input.GetButton("Fire1") && gameObject.GetComponent<PlayerController>().FiringAllowed && !ServiceLocator.GetService<GameManager>().isTouchInput)
        {
            Fire();
                  
        }          
	}

    public void Fire()
    {
        if (cooldownTemp >= cooldownTime)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed * (ServiceLocator.GetService<PlayerController>().IsLookingLeft() ? -1 : 1);
            if (ServiceLocator.GetService<PlayerController>().IsLookingLeft())
            {
                bullet.transform.localScale = new Vector3(bullet.transform.localScale.x * -1, bullet.transform.localScale.y * -1, bullet.transform.localScale.z * -1);
            }
            Destroy(bullet, 2.0f);


            flash.gameObject.SetActive(true);
            Invoke("turnOffMuzzleFlash", 0.1f);

            ServiceLocator.GetService<AudioManager>().PlayGunShotSFX();
            cooldownTemp = 0;
        }
    }

    void turnOffMuzzleFlash()
    {
        flash.gameObject.SetActive(false);
    }
}
