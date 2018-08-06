using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour {

    [Header("• Properties")]
    public float Speed;
    //public Weapon Weapon;
    public float Health;
    public float HitPower;
    public bool CanJump;

    public float followDistance;
    public float attackDistance;

    [Space]
    [Header("• References")]
    public GameObject healthpickup;




    //-------------- Privates ------------------

    protected Rigidbody2D myRigidBody;

    protected HealthSystem healthsystem;
    protected Slider healthslider;
    protected TextMeshProUGUI healthtext;

    protected Transform Target;

    protected void Start()
    {      
        healthsystem = gameObject.AddComponent<HealthSystem>();
        healthslider = transform.GetComponentInChildren<Slider>();
        healthtext = transform.GetComponentInChildren<TextMeshProUGUI>();
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();

        healthsystem.maxHealth = Health;
        //Target = ServiceLocator.GetService<PlayerController>().transform;
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public void Update()
    {
        if (healthsystem.IsDead())
        {
            if (Mathf.Round(Random.Range(0, 2)) == 1)
            {
                GameObject health = Instantiate(healthpickup, transform.position, transform.rotation);
                health.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
            }
            Destroy(this.gameObject);


        }

        healthslider.value = healthsystem.GetHealth() / healthsystem.GetMaxHealth();
        healthtext.SetText(Mathf.Ceil(healthsystem.GetHealth() / healthsystem.GetMaxHealth() * 100) + "%");


    }




}
