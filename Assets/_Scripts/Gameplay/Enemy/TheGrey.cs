using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TheGrey : Enemy
{
    [Space]
    [Header("• Grey Specific")]
    public float MeleeRange;
    public GameObject BloodParticleFX;


    private float width;


    private new void Start()
    {
        base.Start();
        width = transform.gameObject.GetComponent<CapsuleCollider2D>().size.x * transform.localScale.x;
    }


    public new void Update()
    {
        if (!ServiceLocator.GetService<GameManager>().isGameON) return;
        base.Update();
    }


    protected new void Follow(int sign)
    {
        if (Target.position.x - transform.position.x < 5 & Target.position.x - transform.position.x > -5) // Stop
        {
            myRigidBody.velocity = new Vector2(0, 0);
            anim.SetBool("Run", false);
        }
        else
            base.Follow(sign);
    }

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
        anim.Play("Rogue_attack_03");
        yield return new WaitForSeconds(12 / 60f);
        Attack();
        yield return new WaitForSeconds(23 / 60f);
        Attack();
        
    }

    void Attack()
    {
        if (!healthsystem.IsDead())
        {
            int lookleftorright = (myBody.localScale.x < 0) ? -1 : 1;
            RaycastHit2D hit = (Physics2D.Raycast(new Vector2(transform.position.x + width * lookleftorright, transform.position.y + 1f), transform.right, MeleeRange * lookleftorright));
            Debug.DrawLine(new Vector2(transform.position.x + width * lookleftorright, transform.position.y + 1f), new Vector2(transform.position.x + MeleeRange * lookleftorright, transform.position.y + 1f), Color.cyan, 1f);

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
