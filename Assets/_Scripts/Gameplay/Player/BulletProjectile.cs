﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour {

    public GameObject BloodParticleFX;
    public GameObject GroundParticleFX;
    private int Dmg;
    // Update is called once per frame
    private void Start()
    {
        Dmg = ServiceLocator.GetService<RangedWeapon>().PistolDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !collision.gameObject.GetComponent<HealthSystem>().IsDead())
        {
            collision.gameObject.GetComponent<HealthSystem>().Damage(Dmg);
            Invoke("PlayBloodFX", 0.04f);
            Destroy(this.gameObject, 0.04f);

        }
        else if (collision.CompareTag("Ground"))
        {
            Invoke("PlayGroundFX", 0.04f);
            Destroy(this.gameObject, 0.04f);

        }
    }

    private void PlayBloodFX()
    {
        GameObject particle = Instantiate(BloodParticleFX, this.transform.position, this.transform.rotation);
        Destroy(particle, 1f);
    }

    private void PlayGroundFX()
    {
        GameObject particle = Instantiate(GroundParticleFX, this.transform.position, this.transform.rotation);
        Destroy(particle, 1f);
    }

}