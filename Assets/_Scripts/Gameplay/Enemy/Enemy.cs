using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour {

    [Header("• Properties")]
    public float Speed;
    public float Health;
    public int HitPower;
    public bool CanJump;

    [Space]
    [Header("• References")]
    public GameObject healthpickup;
    public Transform Target;

    [HideInInspector]
    public Rigidbody2D myRigidBody;


    //-------------- Privates ------------------

    protected HealthSystem healthsystem;
    private Slider healthslider;
    private TextMeshProUGUI healthtext;
    protected bool Dead = false; // to not spawn multiple pickups on death
    protected Animator anim;

    protected Transform myBody;
    protected bool isLookingLeft;

    [Space]
    public float attackDelay;
    public float attackDelayTemp = 0;
    public float followDistance;
    public float attackDistance;

    public void Start()
    {   
        // health
        healthsystem = gameObject.AddComponent<HealthSystem>();
        healthslider = transform.GetComponentInChildren<Slider>();
        healthtext = transform.GetComponentInChildren<TextMeshProUGUI>();
        healthsystem.SetMaxHealth(Health);


        // related
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myBody = transform.Find("Rogue_pelvis_01");


        // other
        Target = ServiceLocator.GetService<PlayerController>().transform;
        Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), ServiceLocator.GetService<PickupSystem>().GetComponent<BoxCollider2D>(), true);

        
    }


    public void Update()
    {

        CheckHealth();
        if (!healthsystem.IsDead())
        {
            HandleTransitions();
            Flip();
        }

    }

    protected void HandleTransitions()
    {
        float distanceOverX = Target.position.x - transform.position.x;
        attackDelayTemp += Time.deltaTime;

        if (Mathf.Abs(distanceOverX) < attackDistance) // in attack distance
        {
            Idle();
            if (attackDelayTemp >= attackDelay) // attack
            {
                attackDelayTemp = 0;
                StartCoroutine(AttackCoroutine());
            }
        }
        else if (Mathf.Abs(distanceOverX) < followDistance) // in follow distance
        {
            Follow(distanceOverX < 0 ? -1 : 1);
        }
        else // out of follow/attack range
        {
            Idle();
        }
    }

    private void CheckHealth()
    {
        healthslider.value = healthsystem.GetHealth() / healthsystem.GetMaxHealth();
        healthtext.SetText(Mathf.Ceil(healthsystem.GetHealth() / healthsystem.GetMaxHealth() * 100) + "%");

        if (healthsystem.IsDead() && !Dead)
        {
            


            Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), Target.GetComponent<CapsuleCollider2D>());
            healthslider.enabled = false;
            healthtext.enabled = false;
            Dead = true;
            anim.Play("Rogue_death_01");
            ServiceLocator.GetService<ScoreManager>().addScore(30);


           // if (!Died)// Mathf.Round(Random.Range(0, 2)) == 1)
           // {
                GameObject health = Instantiate(healthpickup, transform.position, transform.rotation);
                health.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);

            // }

            
            Destroy( this.gameObject  , 1);
            transform.parent.GetComponent<EnemySpawner>().EnemyDied(gameObject);
        }

        
    }

    virtual public void OnPlayerDied()
    {
       Debug.Log("Enemy Parent Class : OnPlayer Died");
    }

    protected void Idle()
    {
        anim.SetBool("Run", false);
    }

    protected void Follow(int sign)
    {
        anim.SetBool("Run", true);
        myRigidBody.velocity = new Vector2(sign * Speed, myRigidBody.velocity.y);
    }

    protected void Flip()
    {
        if ((Target.position.x > transform.position.x && isLookingLeft) || (Target.position.x < transform.position.x && !isLookingLeft))
        {
            myBody.localScale = new Vector3(-1 * myBody.localScale.x, myBody.localScale.y, myBody.localScale.z);
            isLookingLeft = !isLookingLeft;
        }
    }

    abstract protected IEnumerator AttackCoroutine();
}
