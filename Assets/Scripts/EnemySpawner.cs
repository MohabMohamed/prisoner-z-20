using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    private HealthSystem healthsystem;
	// Use this for initialization
	void Start () {
        healthsystem = new HealthSystem(this.GetComponent<Rigidbody2D>(), 40);
	}
	
	// Update is called once per frame
	void Update () {
        if (healthsystem.IsDead()) 
        {
            Destroy(this);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
            healthsystem.Damage(20);
    }
}
