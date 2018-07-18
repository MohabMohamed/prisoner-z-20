using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Bullet bullet;
    public float bulletSpeed;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
          Bullet clone = (Bullet)Instantiate(bullet, transform.position, transform.rotation);
            clone.GetComponent<Rigidbody2D>().AddForce(clone.transform.right*bulletSpeed);
        }
	}
}
