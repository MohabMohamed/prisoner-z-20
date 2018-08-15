using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheGreen : Enemy
{
    public float ProjectileVelocity;
    public GameObject Projectile;


    GameObject fireball;

    private new void Start()
    {
        base.Start();
    }


    public new void Update()
    {
        if (!ServiceLocator.GetService<GameManager>().isGameON) return;
        base.Update();
    }



    protected override IEnumerator AttackCoroutine()
    {
        //Debug.Log("TheGreenAttack");
        yield return null;
        if (Target!=null)
            createCurve();

        



        /*
    GameObject fireball = fireball = Instantiate(Projectile, transform.position, Quaternion.identity);
    //fireball = Instantiate(Projectile, transform.position, getProjectileAngle());
    fireball.GetComponent<Rigidbody2D>().velocity = getProjectileVelocity(Target.position.x - transform.position.x, Target.position.y - transform.position.y, -Physics2D.gravity.y, 45);
    //fireball.transform.right * ProjectileVelocity;
       */
    }

    void createCurve()
    {
        if (fireball == null)
        {
            fireball = Instantiate(Projectile, transform.position, Quaternion.identity);


            BezierCurve projectileCurve = new GameObject().AddComponent<BezierCurve>(); // fireball.AddComponent<BezierCurve>();

            GameObject startPoint = new GameObject("startPoint");
            GameObject endPoint = new GameObject("endPoint");

            startPoint.transform.position = transform.position + new Vector3(0, 1f);
            endPoint.transform.position = Target.position + new Vector3(0, 0.8f);

            float max = Mathf.Max(startPoint.transform.position.y, endPoint.transform.position.y);

            projectileCurve.AddPointAt(startPoint.transform.position);
            projectileCurve.AddPointAt(new Vector2((startPoint.transform.position.x + endPoint.transform.position.x) / 2, 1f + max)).setHandleX(isLookingLeft ? -2f : 2f);
            projectileCurve.AddPointAt(endPoint.transform.position);


            fireball.AddComponent<CurveFollow>().curve = projectileCurve;
            fireball.GetComponent<CurveFollow>().MoveFireBallProjectile(HitPower, 0.5f + map(Vector3.Distance(transform.position, Target.position), 0, 45, 0, 3));


            Destroy(startPoint);
            Destroy(endPoint);
        }
    }

    override
public void OnPlayerDied()
    {
        //Debug.Log(name + " Knew that player is dead.");

        Idle();
    }

    /*Vector2 getProjectileVelocity(float distanceX, float distanceY, float gravity, float angle)
    {
 
        distanceX = Mathf.Abs(distanceX);
        float TotalSpeed;
        Vector2 Solution;
        TotalSpeed = (1 / Mathf.Cos(angle * Mathf.Deg2Rad)) * Mathf.Sqrt(0.5F * distanceX * distanceX * gravity / (distanceY + Mathf.Tan(angle * Mathf.Deg2Rad) * distanceX));
        Solution.x = TotalSpeed * Mathf.Cos(angle * Mathf.Deg2Rad) * (isLookingLeft ? -1 : 1);
        Solution.y = TotalSpeed * Mathf.Sin(angle * Mathf.Deg2Rad);
        print(Solution);
        return Solution;
    }*/



    /*private Quaternion getProjectileAngle()
    {

        float x = Target.position.x - transform.position.x;
        float y = Target.position.y - transform.position.y;
        float g = Physics2D.gravity.y;
        

        float angle = 
            
            Mathf.Atan
            (
            
                (Mathf.Pow(ProjectileVelocity, 2) + 
                Mathf.Sqrt( 
                    Mathf.Pow(ProjectileVelocity, 4) - 
                    g*(g*Mathf.Pow(x,2)) + 
                    2*y*Mathf.Pow(ProjectileVelocity,2)   
                ))
                / g*x
            
            )
            * Mathf.Rad2Deg;



        Debug.Log("Angle: " + angle);
        Vector3 Euler = new Vector3(0, 0, angle+90);
        Quaternion Q = Quaternion.Euler(Euler);

       
        return Q;
    }*/








}
