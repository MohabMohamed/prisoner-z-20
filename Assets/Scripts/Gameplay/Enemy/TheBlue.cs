using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBlue: Enemy {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    //public float FireRate;
    public float FireSpeed;
    //private bool canAttack = true;
    public float attackDelay;
    public float attackDelayTemp = 0;

    private Transform myBody;
    bool isLookingLeft;
    Animator anim;

    void Start()
    {
        base.Start();
        attackDelayTemp = attackDelay;
        isLookingLeft = false;

        myBody = transform.Find("Rogue_pelvis_01");
        anim = GetComponent<Animator>();
    }

    void Update() {
        base.Update();
        HandleTransitions();

        flip();
    }

    void flip()
    {
        if((Target.position.x > transform.position.x && isLookingLeft) || (Target.position.x < transform.position.x && !isLookingLeft))
        {
            myBody.localScale = new Vector3(-1 * myBody.localScale.x , myBody.localScale.y, myBody.localScale.z);
            isLookingLeft = !isLookingLeft;
        }
    }

    // method handle transitions
    // state object assigned depending on current enemy state
    ///////////////////



    // method handle transitions
    private void HandleTransitions()
    {
        if (Target == null)
        {
            Target = ServiceLocator.GetService<PlayerController>().transform;
        }
        float distanceOverX = Target.position.x - transform.position.x;
        attackDelayTemp += Time.deltaTime;

        if (Mathf.Abs(distanceOverX) < attackDistance)
        {
            if (attackDelayTemp >= attackDelay)
            {
                attackDelayTemp = 0;
                Attack();
            }
        }
        else if (Mathf.Abs(distanceOverX) < followDistance) {
            Follow(distanceOverX < 0 ? -1 : 1);
        }
        else
        {
            Idle();
        }
    }
    // method idle
    private void Idle()
    {
        anim.SetBool("Run", false);
        myRigidBody.velocity = Vector3.zero;
    }
    // method follow
    private void Follow(int sign)
    {
        anim.SetBool("Run", true);
        myRigidBody.velocity = new Vector2(sign * Speed, 0);
    }
    // method attack
    private void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        Vector2 direction = (Target.position + new Vector3(0, 1, 0) - bulletSpawn.position).normalized;
        bullet.transform.Rotate(bullet.transform.forward,Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x));
        Debug.Log(Mathf.Atan2(direction.y, direction.x));
        Debug.Log(
            "Target: " + Target.position
            +"\nbulletSpawnPosition: " + bulletSpawn.position
            + "\n Direction: " + direction);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * FireSpeed;
    }
    // method death


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log(healthsystem);
            healthsystem.Damage(20);
        }
    }

}
