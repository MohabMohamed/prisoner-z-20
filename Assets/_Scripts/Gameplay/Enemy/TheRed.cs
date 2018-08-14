using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheRed : Enemy {

    [Space]
    public EnemySword mySwordRef;

    [Space]
    [Header("Boss Properties")]
    public float MeleeAttackDelay;
    public float MeleeFollowDistance;
    public float MeleeAttackDistance;
    [Space]
    public float RangedAttackDelay;
    public float RangedFollowDistance;
    public float RangedAttackDistance;

    [Space]
    public GameObject[] RangedThrowables;


    private float width;
    PlayerController player;




    private new void Start () {
        base.Start();

        player = Target.GetComponent<PlayerController>();
        width = transform.gameObject.GetComponent<CapsuleCollider2D>().size.x * transform.localScale.x;
    }
	
	
	public new void Update () {
        base.Update();

        if (player.isPlayerOnPlatform)
        {
            isMelee = false;
            attackDelay = RangedAttackDelay;
            //attackDelayTemp = attackDelay;
            followDistance = RangedFollowDistance;
            attackDistance = RangedAttackDistance;
        }
        else
        {
            isMelee = true;
            attackDelay = MeleeAttackDelay;
            //attackDelayTemp = attackDelay;
            followDistance = MeleeFollowDistance;
            attackDistance = MeleeAttackDistance;
        }
    }


    override
public void OnPlayerDied()
    {
        Debug.Log(name + " Knew that player is dead.");

        Idle();
    }

    protected override void CheckHealth()
    {
        if(healthsystem.IsDead() && !Dead)
        {
            print("bosswaveend");
            ServiceLocator.GetService<GameManager>().endWave();
        }
        base.CheckHealth();
       
    }

    protected override IEnumerator AttackCoroutine()
    {
        if (isMelee)
        {
            anim.Play("RedMelee");
        }
        else
        {
            ThrowRangedThrowable();
        }
        yield return null;
    }

    void ThrowRangedThrowable()
    {
        


        BezierCurve projectileCurve = new GameObject().AddComponent<BezierCurve>(); // fireball.AddComponent<BezierCurve>();

        GameObject startPoint = new GameObject("startPoint");
        GameObject endPoint = new GameObject("endPoint");

        startPoint.transform.position = transform.position + new Vector3(isLookingLeft? -width : width, 1f);
        endPoint.transform.position = Target.position + new Vector3(0, 0.8f);

        float max = Mathf.Max(startPoint.transform.position.y, endPoint.transform.position.y);

        projectileCurve.AddPointAt(startPoint.transform.position);
        projectileCurve.AddPointAt(new Vector2((startPoint.transform.position.x + endPoint.transform.position.x) / 2, 1f + max)).setHandleX(isLookingLeft ? -1.8f : 1.8f);
        projectileCurve.AddPointAt(endPoint.transform.position);


        GameObject projectile = Instantiate(RangedThrowables[Random.Range(0, RangedThrowables.Length)], startPoint.transform.position, Quaternion.identity);

        //projectile.AddComponent<CurveFollow>().curve = projectileCurve;
        projectile.GetComponent<CurveFollow>().curve = projectileCurve;
        projectile.GetComponent<CurveFollow>().Move(0.5f + map(Vector3.Distance(transform.position, Target.position), 0, 45, 0, 3));


        Destroy(startPoint);
        Destroy(endPoint);
        Destroy(projectileCurve, 3f);
    }


    public void OnSwordHitThePlayer()
    {
        DeactivateSword();

        //Debug.Log("SwordHitPlayer");
        Target.GetComponent<HealthSystem>().Damage(HitPower);
    }

    public void ActivateSword()
    {
        mySwordRef.GetComponent<Collider2D>().enabled = true;
        //Debug.Log("ActivateSword");
    }
    public void DeactivateSword()
    {
        mySwordRef.GetComponent<Collider2D>().enabled = false;
        Debug.Log("DisableSword");
    }

    protected override void Idle()
    {
        anim.SetBool("Walk", false);

    }

    protected override void Follow(int sign)
    {
        anim.SetBool("Walk", true);
        myRigidBody.velocity = new Vector2(sign * Speed, myRigidBody.velocity.y);
    }
}
