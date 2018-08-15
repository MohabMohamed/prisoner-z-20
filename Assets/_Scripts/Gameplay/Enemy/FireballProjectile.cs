using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour {


    private Rigidbody2D myRigidBody;
    public GameObject explosioneffect;
    Transform PlayerTarget;

    void Start() {

        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
        PlayerTarget = ServiceLocator.GetService<TheGreen>().Target;
    }


    public void Explode(int dmg)
    {
        GameObject explosion = Instantiate(explosioneffect, transform.position, Quaternion.identity);
        Destroy(explosion, 1f);
        if (Vector3.Distance(PlayerTarget.position, transform.position) < 2 )
        {
            PlayerTarget.GetComponent<HealthSystem>().Damage(dmg);
        }
        print("destroyed");
        Destroy(gameObject, 0.03f);
        
    }
    
    
}
