using System.Collections;
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
    
    


    private HealthSystem health;

	void Start () {
        health = gameObject.GetComponent<HealthSystem>();
	}
	

	void Update () {
        if (!health.IsDead() && Input.GetButtonDown("Fire1") && gameObject.GetComponent<PlayerController>().FiringAllowed)
        {
            Fire();          
        }          
	}

    public void Fire()
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
    }

    void turnOffMuzzleFlash()
    {
        flash.gameObject.SetActive(false);
    }
}
