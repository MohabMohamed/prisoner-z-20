using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TheOrange : Enemy {

    
    
    private Transform body;
    private Transform player;
    private float width;


    [Space]
    //Melee
    public float MeleeRange;
    float cooldowntime = 4f;
    float cooldowntemp = 0f;

    public GameObject BloodParticleFX;

    private new void Start()
    {
        base.Start();
        
        body = transform.Find("Rogue_pelvis_01");
        player = transform;
        width = player.gameObject.GetComponent<CapsuleCollider2D>().size.x * player.localScale.x;

        
    }
    public new void Update()
    {
        if (!ServiceLocator.GetService<GameManager>().isGameON) return;

        if (!Dead)
        {
            base.Update();
            //Follow();
            //HitIfClose();
        }

    }

    


    /*void Follow()
    {
        if (Target == null)
        {
            Target = ServiceLocator.GetService<PlayerController>().transform;
        }
        // Follow & Set Animation
        if (Target.position.x - transform.position.x < 2 & Target.position.x - transform.position.x > -2) // Stop
        {
            myRigidBody.velocity = new Vector2(0, 0);
            anim.SetBool("Run", false);
        }
        else if (Target.position.x < transform.position.x) // Move Left
        {
            myRigidBody.velocity = new Vector2(-Speed, myRigidBody.velocity.y);
            anim.SetBool("Run", true);
            if (!isLookingLeft) // Check Flip
            {
                body.localScale = new Vector3(-1 * body.localScale.x, body.localScale.y, body.localScale.z);
                isLookingLeft = true;
            }
        }
        else if (Target.position.x > transform.position.x) // Move Right
        {
            myRigidBody.velocity = new Vector2(Speed, myRigidBody.velocity.y);
            anim.SetBool("Run", true);
            if (isLookingLeft) // Check Flip
            {
                body.localScale = new Vector3(-1 * body.localScale.x, body.localScale.y, body.localScale.z);
                isLookingLeft = false;
            }
        }
    }*/


    /*void HitIfClose()
    {
        if (cooldowntemp > 0)
            cooldowntemp -= Time.deltaTime;
        else if (cooldowntemp <= 0 && (Target.position.x - transform.position.x < 4 && Target.position.x - transform.position.x > -4) && Vector2.Distance(Target.position, transform.position) < 6)
        {
            anim.Play("OrangeMelee");
            cooldowntemp = cooldowntime;
            StartCoroutine(AttackCoroutine());
        }

    }*/


    override
    public void OnPlayerDied()
    {
        Debug.Log(name + " Knew that player is dead.");

        StopMoving();

    }

    void StopMoving()
    {

        anim.SetBool("Run", false);
    }

    protected override IEnumerator AttackCoroutine()
    {
        anim.Play("OrangeMelee");
        yield return new WaitForSeconds(0.6f);
        if (!healthsystem.IsDead())
        {
            int lookleftorright = (body.localScale.x < 0) ? -1 : 1;
            RaycastHit2D hit = (Physics2D.Raycast(new Vector2(player.position.x + width * lookleftorright, player.position.y + 1f), player.right, MeleeRange * lookleftorright));
            Debug.DrawLine(new Vector2(player.position.x + width * lookleftorright, player.position.y + 1f), new Vector2(player.position.x + MeleeRange * lookleftorright, player.position.y + 1f), Color.cyan, 1f);

            if (hit && hit.transform.CompareTag("Player"))
            {
                print("should hit player");
                hit.transform.gameObject.GetComponent<HealthSystem>().Damage(HitPower);
                GameObject BloodFX = Instantiate(BloodParticleFX, hit.point, hit.transform.rotation);
                Destroy(BloodFX, 1f);
            }
        }
    }
}
