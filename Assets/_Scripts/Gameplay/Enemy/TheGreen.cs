using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheGreen : Enemy
{
    public float ProjectileVelocity;
    public GameObject Projectile;

    private new void Start()
    {
        base.Start();
    }


    public new void Update()
    {
        base.Update();
    }



    protected override IEnumerator AttackCoroutine()
    {
        yield return null;
        GameObject fireball = fireball = Instantiate(Projectile, transform.position, Quaternion.identity);

        //fireball = Instantiate(Projectile, transform.position, getProjectileAngle());




        fireball.GetComponent<Rigidbody2D>().velocity = getProjectileVelocity(Target.position.x - transform.position.x, Target.position.y - transform.position.y, -Physics2D.gravity.y, 45);
        //fireball.transform.right * ProjectileVelocity;
           
    }

    Vector2 getProjectileVelocity(float distanceX, float distanceY, float gravity, float angle)
    {
 
        distanceX = Mathf.Abs(distanceX);
        float TotalSpeed;
        Vector2 Solution;
        TotalSpeed = (1 / Mathf.Cos(angle * Mathf.Deg2Rad)) * Mathf.Sqrt(0.5F * distanceX * distanceX * gravity / (distanceY + Mathf.Tan(angle * Mathf.Deg2Rad) * distanceX));
        Solution.x = TotalSpeed * Mathf.Cos(angle * Mathf.Deg2Rad);
        Solution.y = TotalSpeed * Mathf.Sin(angle * Mathf.Deg2Rad);
        print(Solution);
        return Solution;
    }



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



    override
    public void OnPlayerDied()
    {
        Debug.Log(name + " Knew that player is dead.");

        Idle();
    }




}
