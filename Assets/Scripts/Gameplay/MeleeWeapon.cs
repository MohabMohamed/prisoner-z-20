using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {

    Animator anim;
    public Collider2D SwordCollider;

    float cooldowntime = 0.9f;
    float collidertime = 0.6f;
    float collidertemp = 0f;
    float cooldowntemp = 0f;
    HealthSystem health;


    void Start () {
        anim = GetComponent<Animator>();
        health = gameObject.GetComponent<HealthSystem>();
    }
	


	void Update () {


        if (!health.IsDead())
        {
            if (cooldowntemp > 0)
                cooldowntemp -= Time.deltaTime;
            else if (Input.GetButtonDown("Fire1"))
            {
                anim.Play("PlayerMelee");
                cooldowntemp = cooldowntime;
                collidertemp = collidertime;
            }

            

            if (collidertemp > 0)
                collidertemp -= Time.deltaTime;
            else
                StartCoroutine(ColliderRoutine());
        }
        
    }

    IEnumerator ColliderRoutine()
    {
        SwordCollider.enabled = true;
        yield return null;
        SwordCollider.enabled = false;
    }
}
