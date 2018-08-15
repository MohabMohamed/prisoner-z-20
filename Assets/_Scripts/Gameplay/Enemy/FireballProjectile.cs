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

        Destroy(explosion, 1);

        if (Vector3.Distance(PlayerTarget.position, transform.position) < 2 )
        {
            PlayerTarget.GetComponent<HealthSystem>().Damage(dmg);
        }

        //print("Fireball Explode");


        LeanTween.cancel(gameObject);
        Destroy(gameObject.GetComponent<CurveFollow>().curve);
        Destroy(gameObject);     
    }
    
    
}
