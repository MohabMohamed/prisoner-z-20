using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBlue: Enemy {




    //public float FireRate;
    //private bool canAttack = true;

    [Space]
    [Header("• Blue Specific")]
    public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public float projectileSpeed;
    public GameObject ShurikenSprite;
    
    



    new void Start()
    {
        base.Start();
        attackDelayTemp = attackDelay;
        isLookingLeft = false;

        followDistance = Random.Range(followDistance - followDistance/3, followDistance + followDistance / 3);
        attackDistance = Random.Range(attackDistance - attackDistance / 3, attackDistance + attackDistance / 3);
                     
    }


    new void Update() {
        if (!ServiceLocator.GetService<GameManager>().isGameON) return;
        

        if (!Dead)
        {
            base.Update();
        }

   

    }



   
    
    // state object assigned depending on current enemy state
    
  

    protected override IEnumerator AttackCoroutine()
    {
        anim.Play("ThrowShuriken_01");
        ShurikenSprite.SetActive(true);
        yield return new WaitForSeconds(1.23f);

        // throw projectile
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation);
        Destroy(projectile, 4f);
        Vector2 direction = (Target.position + new Vector3(0, 1, 0) - projectileSpawn.position).normalized;
        projectile.transform.Rotate(projectile.transform.forward, Mathf.Rad2Deg * Mathf.Atan2(direction.y, direction.x));
        projectile.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
        // end of throw projectile

        ShurikenSprite.SetActive(false);
    }



    private void OnTriggerStay2D(Collider2D collision)
    {

        if (!healthsystem.IsDead())
        {

            if (collision.CompareTag("RightJumpPathTrigger") && myRigidBody.velocity.x < -0.5) // already moving left
            {


                gameObject.GetComponent<CurveFollow>().curve = collision.transform.parent.GetComponent<BezierCurve>();
                gameObject.GetComponent<CurveFollow>().Move();


                collision.enabled = false;
                LeanTween.delayedCall(1, () => { collision.enabled = true; });

            }
            else if (collision.CompareTag("LeftJumpPathTrigger") && myRigidBody.velocity.x > 0.5) // already moving right
            {


                gameObject.GetComponent<CurveFollow>().curve = collision.transform.parent.GetComponent<BezierCurve>();
                gameObject.GetComponent<CurveFollow>().Move();


                collision.enabled = false;
                LeanTween.delayedCall(1, () => { collision.enabled = true; });
            }
        }
        
        
    }

    public override void OnPlayerDied()
    {
        Debug.Log(name + " Knew that player is dead.");

        StopMoving();
    }

    void StopMoving()
    {
        anim.SetBool("Run", false);
    }

} // end class
