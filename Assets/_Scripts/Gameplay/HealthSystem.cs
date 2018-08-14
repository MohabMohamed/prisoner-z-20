using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour {


    [SerializeField]
    private float maxHealth;
    private float currentHealth;


    private Animator anim;


    private void Awake()
    {      
        currentHealth = maxHealth;
        anim = gameObject.GetComponent<Animator>();
    }


    public void Damage(int dmgNo)
    {
        if (currentHealth > 0)
        {
            currentHealth -= dmgNo;
            if (this.CompareTag("Player"))
            {
                ServiceLocator.GetService<UIManager>().UpdateHealtBar();
                ServiceLocator.GetService<AudioManager>().PlayPlayerHitSFX();

                Physics2D.IgnoreLayerCollision( 8 , 9 , false);

                if (currentHealth <= 0)  ServiceLocator.GetService<GameManager>().OnPlayerDied();
            }
            /*else if (currentHealth <= 0)
            {

                print(this.name + " Dead");
            }*/
        }        
    }


    public void Heal(int healNo)
    {

        currentHealth += healNo;

        if (currentHealth >= maxHealth)
        {
            print("Cannot heal, already at full health");
            Physics2D.IgnoreLayerCollision(8, 9, true);
            currentHealth = maxHealth;
        }

         ServiceLocator.GetService<UIManager>().UpdateHealtBar();
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
        currentHealth = maxHealth;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
