using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            // Create the Bullet from the Bullet Prefab
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * speed;

            // Destroy the bullet after 2 seconds
            Destroy(bullet, 2.0f);

            
        }
           
	}
}
