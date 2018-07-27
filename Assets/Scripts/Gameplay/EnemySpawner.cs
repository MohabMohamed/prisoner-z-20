using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawner : MonoBehaviour {

    private HealthSystem healthsystem;
    public GameObject healthpickup;

    public Slider healthslider;
    public TextMeshProUGUI healthtext;
    

	void Start () {
        this.gameObject.AddComponent < HealthSystem > ();
        healthsystem = this.gameObject.GetComponent<HealthSystem>();

       
	}
	
	
	void Update () {
        if (healthsystem.IsDead())
        {
            if (Mathf.Round(Random.Range(0, 2)) == 1)
            {
                    GameObject health =  Instantiate(healthpickup, transform.position, transform.rotation);
                    health.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
            }
            Destroy(this.gameObject);
            

        }

        healthslider.value = healthsystem.GetHealth() / healthsystem.GetMaxHealth();
        healthtext.SetText( Mathf.Ceil(healthsystem.GetHealth() / healthsystem.GetMaxHealth() * 100 ) + "%");


	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            
            healthsystem.Damage(20);
           
        }
    }
}
