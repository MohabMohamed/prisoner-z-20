using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TheOrange : Enemy {

    private Transform FollowTarget;
    private Rigidbody2D RIGID;
    private Animator anim;
    private Transform body;

    bool isLookingLeft = false;
    [Space]
    public float hitRadius;



    //Melee
    public Collider2D SwordCollider;
    float cooldowntime = 4f;
    float collidertime = 1.05f;
    float cooldowntemp = 0f;
    float collidertemp = 0f;

    private new void Start()
    {
        base.Start();
        RIGID = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        body = transform.Find("Rogue_pelvis_01");
    }
    public new void Update()
    {
        base.Update();
        FollowTarget = GetTargetTransform();



        Follow();

        HitIfClose();








    }

    void HitIfClose()
    {
        if (cooldowntemp <= 0 && FollowTarget.position.x - transform.position.x < 4 && FollowTarget.position.x - transform.position.x > -4)
        {

            anim.Play("OrangeMelee");
            cooldowntemp = cooldowntime;
            collidertemp = collidertime;
        }


        if (cooldowntemp > 0)
            cooldowntemp -= Time.deltaTime;

        if (collidertemp > 0)
            collidertemp -= Time.deltaTime;
        else
            StartCoroutine(ColliderRoutine());

    }

    void Follow()
    {
        // Follow & Set Animation
        if (FollowTarget.position.x - transform.position.x < 2 & FollowTarget.position.x - transform.position.x > -2)
        {
            RIGID.velocity = new Vector2(0, 0);
            anim.SetBool("Run", false);
        }
        else if (FollowTarget.position.x < transform.position.x)
        {
            RIGID.velocity = new Vector2(-Speed, RIGID.velocity.y);
            anim.SetBool("Run", true);
            if (!isLookingLeft) // Check Flip
            {
                body.localScale = new Vector3(-1 * body.localScale.x, body.localScale.y, body.localScale.z);
                isLookingLeft = true;
            }
        }
        else if (FollowTarget.position.x > transform.position.x)
        {
            RIGID.velocity = new Vector2(Speed, RIGID.velocity.y);
            anim.SetBool("Run", true);
            if (isLookingLeft) // Check Flip
            {
                body.localScale = new Vector3(-1 * body.localScale.x, body.localScale.y, body.localScale.z);
                isLookingLeft = false;
            }
        }
    }



    

    IEnumerator ColliderRoutine()
    {
        SwordCollider.enabled = true;
        yield return null;
        SwordCollider.enabled = false;
    }

}
