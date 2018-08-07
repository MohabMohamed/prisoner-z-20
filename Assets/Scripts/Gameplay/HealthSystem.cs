using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {


    [SerializeField]
    private float maxHealth;
    private float currentHealth;


    private Animator anim;
    
    private void Start()
    {
        currentHealth = maxHealth;
        anim = gameObject.GetComponent<Animator>();
    }


    public void Damage(int dmgNo)
    {
        
        currentHealth -= dmgNo;
        if (this.CompareTag("Player"))
        {
            ServiceLocator.GetService<AudioManager>().PlayPlayerHitSFX();
            print(this.name + " Health: " + currentHealth);
        }
        if (currentHealth <= 0)
        {
            
            print(this.name + " Dead");
        }
        
            



        
    }


    public void Heal(int healNo)
    {
        if (currentHealth >= maxHealth)
            print("Cannot heal, already at full health");
        else
        {
            currentHealth += healNo;
            print(this.name + " Health: " + currentHealth);
        }
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetMaxHealth(float newhealth)
    {
        maxHealth = newhealth;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
