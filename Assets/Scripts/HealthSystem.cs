using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour {

    private int currentHealth;
    private int maxHealth;
    private Rigidbody2D RIGID;


    public HealthSystem(Rigidbody2D RIGID, int Health)
    {
        this.RIGID = RIGID;
        currentHealth = Health;
        maxHealth = Health;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            print("Health: " + currentHealth);

    }

    public void Damage(int dmgNo)
    {
        currentHealth -= dmgNo;
        if (currentHealth <= 0)
        {
            RIGID.gameObject.SetActive(false);
            print("Dead");
        }
        else
            print("Health: " + currentHealth);



        
    }


    public void Heal(int healNo)
    {
        currentHealth += healNo;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        else if (currentHealth == maxHealth)
            print("Cannot heal, already at full health");

        print("Health: " + currentHealth);



        
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
