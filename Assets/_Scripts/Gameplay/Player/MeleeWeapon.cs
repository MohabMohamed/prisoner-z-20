using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour {

    Animator anim;
    HealthSystem health;
    private Transform player;

    public GameObject BloodParticleFX;
    public float MeleeRange;
    public int MeleeDamage;
    private float cooldowntime = 0.9f;
    private float cooldowntemp = 0f;
    private float Width;
    

    void Start () {
        anim = GetComponent<Animator>();
        health = gameObject.GetComponent<HealthSystem>();
        player = transform;
        Width = player.gameObject.GetComponent<CapsuleCollider2D>().size.x * player.localScale.x;
    }
	


	void Update () {

        if(!health.IsDead())
        {
            if (cooldowntemp > 0)
                cooldowntemp -= Time.deltaTime;
            else if (Input.GetButtonDown("Fire1"))
            {
                anim.Play("PlayerMelee");
                cooldowntemp = cooldowntime;
                StartCoroutine(MeleeRoutine());
            }
        }

    }

   IEnumerator MeleeRoutine()
    {
        
        yield return new WaitForSeconds(0.327f);
        int lookleftorright = (player.localScale.x < 0) ? -1 : 1;
        RaycastHit2D hit = (Physics2D.Raycast(new Vector2(player.position.x + Width * lookleftorright, player.position.y+0.5f) , player.right , MeleeRange * lookleftorright));
        Debug.DrawLine(new Vector2(player.position.x + Width * lookleftorright, player.position.y + 0.5f), new Vector2(player.position.x + MeleeRange * lookleftorright , player.position.y + 0.5f) , Color.cyan , 1f);
        
        if (hit && hit.transform.CompareTag("Enemy"))
        {
            hit.transform.gameObject.GetComponent<HealthSystem>().Damage(MeleeDamage);
            GameObject BloodFX = Instantiate(BloodParticleFX, hit.point, hit.transform.rotation);
            Destroy(BloodFX, 1f);
            ServiceLocator.GetService<AudioManager>().PlaySwordHitSFX();
        }
        else
        {
            ServiceLocator.GetService<AudioManager>().PlaySwordWooshSFX();
        }
        
    }
}
