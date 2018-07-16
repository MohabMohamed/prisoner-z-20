using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {

    private int currentHealth;

    private Rigidbody2D RIGID;


    public HealthSystem(Rigidbody2D RIGID, int Health)
    {
        this.RIGID = RIGID;
        currentHealth = Health;
        print("Health: " + currentHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            print("Health: " + currentHealth);

    }

    public void Damage(int dmgNo)
    {
        currentHealth -= dmgNo;
        if (currentHealth < 0)
            currentHealth = 0;

        print("Health: " + currentHealth);
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
