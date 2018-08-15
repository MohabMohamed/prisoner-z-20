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
    public float cameraShakeAmount;
    [Space]
    public float RangedAttackDelay;
    public float RangedFollowDistance;
    public float RangedAttackDistance;

    [Space]
    public GameObject[] RangedThrowables;




    PlayerController player;

    public void ActivateSword()
    {
        mySwordRef.GetComponent<Collider2D>().enabled = true;
    }
    public void DeactivateSword()
    {
        mySwordRef.GetComponent<Collider2D>().enabled = false;
    }
    public void ShakeCamera()
    {
       StartCoroutine(Camera.main.GetComponent<CameraController>().Shake(0.15f, cameraShakeAmount));
    }

    private new void Start () {
        base.Start();

        player = Target.GetComponent<PlayerController>();
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
        GameObject Throwable = Instantiate(RangedThrowables[Random.Range(0 , RangedThrowables.Length)], transform.position, Quaternion.identity);


        BezierCurve projectileCurve = new GameObject().AddComponent<BezierCurve>(); // fireball.AddComponent<BezierCurve>();

        GameObject p1 = new GameObject("p1");
        GameObject p2 = new GameObject("p2");
        GameObject p3 = new GameObject("p3");

        p1.transform.position = transform.position;
        p3.transform.position = Target.position;
        p2.transform.position = (Target.transform.position + transform.transform.position) / 2;// + new Vector3(0, Mathf.Max(p1.transform.position.y , p3.transform.position.y), 0);

        projectileCurve.AddPointAt(p1.transform.position);
        projectileCurve.AddPointAt(new Vector2(p2.transform.position.x, 1f + Mathf.Max(p1.transform.position.y, p3.transform.position.y))).setHandleX(isLookingLeft ? -1 : 1);
        projectileCurve.AddPointAt(p3.transform.position);


        Throwable.AddComponent<CurveFollow>().curve = projectileCurve;
        Throwable.GetComponent<CurveFollow>().Move();


        Destroy(p1);
        Destroy(p2);
        Destroy(p3);
        Destroy(projectileCurve, 3);
    }


    public void OnSwordHitThePlayer()
    {
        DeactivateSword();

        Debug.Log("Ayyyyyyy");
    }
}
