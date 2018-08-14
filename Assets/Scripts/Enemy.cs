using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{

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

    private HealthSystem healthsystem;
    private Slider healthslider;
    private TextMeshProUGUI healthtext;



    public void Start()
    {
        healthsystem = gameObject.AddComponent<HealthSystem>();
        healthslider = transform.GetComponentInChildren<Slider>();
        healthtext = transform.GetComponentInChildren<TextMeshProUGUI>();

        healthsystem.SetMaxHealth(Health);

        myRigidBody = GetComponent<Rigidbody2D>();

    }


    public void Update()
    {

        CheckHealth();

    }

    void CheckHealth()
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

      //  healthslider.value = healthsystem.GetHealth() / healthsystem.GetMaxHealth();
      //  healthtext.SetText(Mathf.Ceil(healthsystem.GetHealth() / healthsystem.GetMaxHealth() * 100) + "%");
    }



}