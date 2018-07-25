using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {

    public float maxHealth;
    private float currentHealth;
    
    private Rigidbody2D RIGID;

    

    
    private void Start()
    {
        currentHealth = maxHealth;
        RIGID = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.K))
            print(this.name + " Health: " + currentHealth);

        

    }

    public void Damage(int dmgNo)
    {
        currentHealth -= dmgNo;
        if (currentHealth <= 0)
        {
            RIGID.gameObject.SetActive(false);
            print(this.name + " Dead");
        }
        else
            print(this.name + " Health: " + currentHealth);



        
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
