using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaProjectile : MonoBehaviour {

    public GameObject BloodParticleFX;
    private int Dmg;
    private Rigidbody2D myRigidBody;

    private void Start()
    {
        Dmg = ServiceLocator.GetService<TheBlue>().HitPower;
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        myRigidBody.angularVelocity = 700;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthSystem>().Damage(Dmg);
            Invoke("PlayBloodFX", 0.04f);
            Destroy(this.gameObject, 0.05f);

        }
        
    }

    private void PlayBloodFX()
    {
        GameObject particle = Instantiate(BloodParticleFX, this.transform.position, this.transform.rotation);
        Destroy(particle, 1f);
    }

}
