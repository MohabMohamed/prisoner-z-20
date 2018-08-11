using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour {


    private int Dmg;
    private Rigidbody2D myRigidBody;
    public GameObject explosioneffect;

    void Start () {
        
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myRigidBody.angularVelocity = 700;
    }
	

	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject explosion = Instantiate(explosioneffect, transform.position, explosioneffect.transform.rotation);
        Destroy(explosion, 1f);
        Destroy(gameObject);
    }
    
}
