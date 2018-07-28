using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour {

    [Header("• Properties")]
    public float Speed;
    public Weapon Weapon;
    public float Health;
    public float HitPower;
    public bool CanJump;

    [Space]
    [Header("• References")]
    public GameObject healthpickup;

   


    //-------------- Privates ------------------

    private HealthSystem healthsystem;
    private Slider healthslider;
    private TextMeshProUGUI healthtext;

    private Transform Target;

    void Start()
    {      
        healthsystem = gameObject.AddComponent<HealthSystem>();
        healthslider = transform.GetComponentInChildren<Slider>();
        healthtext = transform.GetComponentInChildren<TextMeshProUGUI>();

        healthsystem.maxHealth = Health;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {

            healthsystem.Damage(20);

        }
    }

}
