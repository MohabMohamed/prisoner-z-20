using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBlue: Enemy {

    private Transform myBody;
    bool isLookingLeft;
    Animator anim;

    //public float FireRate;
    //private bool canAttack = true;

    [Space]
    public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public float projectileSpeed;
    public GameObject ShurikenSprite;
    
    [Space]
    public float attackDelay;
    public float attackDelayTemp = 0;
    public float followDistance;
    public float attackDistance;

    

    new void Start()
    {
        base.Start();
        attackDelayTemp = attackDelay;
        isLookingLeft = false;

        myBody = transform.Find("Rogue_pelvis_01");
        anim = GetComponent<Animator>();
    }

    new void Update() {
        if (!ServiceLocator.GetService<GameManager>().isGameON) return;
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

    
    // state object assigned depending on current enemy state
    ///////////////////



    
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
            Idle();
            if (attackDelayTemp >= attackDelay)
            {
                attackDelayTemp = 0;
                StartCoroutine(AttackCoroutine());
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
    

    private void Idle()
    {
        anim.SetBool("Run", false);
        
    }
    

    private void Follow(int sign)
    {
        anim.SetBool("Run", true);
        myRigidBody.velocity = new Vector2(sign * Speed, myRigidBody.velocity.y);
    }
    

    private void Attack()
    {
        
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation);
        Destroy(projectile, 4f);
        Vector2 direction = (Target.position + new Vector3(0, 1, 0) - projectileSpawn.position).normalized;
        projectile.transform.Rotate(projectile.transform.forward,Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x));
        /*Debug.Log(Mathf.Atan2(direction.y, direction.x));
        Debug.Log(
            "Target: " + Target.position
            +"\nprojectileSpawnPosition: " + projectileSpawn.position
            + "\n Direction: " + direction);*/
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }

    IEnumerator AttackCoroutine()
    {
        anim.Play("BlueThrowShuriken_00");
        ShurikenSprite.SetActive(true);
        yield return new WaitForSeconds(1.23f);
        Attack();
        ShurikenSprite.SetActive(false);
    }
    // method death


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PathTrigger"))
        {
            gameObject.GetComponent<CurveFollow>().enabled = true;
        }
    }


}
