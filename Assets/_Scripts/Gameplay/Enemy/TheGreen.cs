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
        GameObject fireball = Instantiate(Projectile, transform.position + new Vector3(1,1,0), getProjectileAngle());
        fireball.GetComponent<Rigidbody2D>().velocity = fireball.transform.right * ProjectileVelocity;
    }

    private Quaternion getProjectileAngle()
    {

        float x = Target.position.x - transform.position.x;
        float y = Target.position.y - transform.position.y;
        float g = Physics2D.gravity.y;
        

        float angle = 
            
            Mathf.Atan
            (
            
                Mathf.Pow(ProjectileVelocity, 2) - 
                Mathf.Sqrt( 
                    Mathf.Pow(ProjectileVelocity, 4) - 
                    g*(g*Mathf.Pow(x,2)) + 
                    2*y*Mathf.Pow(ProjectileVelocity,2)   
                )
                / g*x
            
            )
            * Mathf.Rad2Deg
            
            ;


        Debug.Log(Mathf.Pow(ProjectileVelocity, 2) +
                Mathf.Sqrt(
                    Mathf.Pow(ProjectileVelocity, 4) -
                    g * (g * Mathf.Pow(x, 2)) +
                    2 * y * Mathf.Pow(ProjectileVelocity, 2)
                )
                / g * x);

        Debug.Log("Angle: " + angle);
        Debug.Log(Mathf.Pow(9, 2));
        Vector3 Euler = new Vector3(0, 0, angle);
        Quaternion Q = Quaternion.Euler(Euler);
       
        return Q;
    }


    override
    public void OnPlayerDied()
    {
        Debug.Log(name + " Knew that player is dead.");

        Idle();
    }




}
