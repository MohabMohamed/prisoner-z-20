using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public GameObject muzzleFlash;
    public AudioSource gunShot;
    public float bulletSpeed;
    public GameObject flash;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed * (ServiceLocator.GetService<PlayerController>().isLookingLeft? -1 : 1);

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);

            
            flash.gameObject.SetActive(true);
            
            Invoke("turnOffMuzzleFlash", 0.1f);
            /*GameObject flash = Instantiate(muzzleFlash, bulletSpawn.position, bulletSpawn.rotation);
            flash.transform.parent = bulletSpawn.transform;
            Destroy(flash, 0.1f);*/

            ServiceLocator.GetService<AudioManager>().PlayGunShotSFX();
            
        }
           
	}

    void turnOffMuzzleFlash()
    {
        flash.gameObject.SetActive(false);
    }
}
