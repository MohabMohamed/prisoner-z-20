using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {

    public float maxHealth;
    private float currentHealth;
    

    

    
    private void Start()
    {
        currentHealth = maxHealth;
    }


    public void Damage(int dmgNo)
    {
        currentHealth -= dmgNo;
        if (currentHealth <= 0)
        {
            print(this.name + " Dead");
        }
        else
            print(this.name + " Health: " + currentHealth);



        
    }


    public void Heal(int healNo)
    {
        if (currentHealth >= maxHealth)
            print("Cannot heal, already at full health");
        else
            currentHealth += healNo;
        

        print("Health: " + currentHealth);



        
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
