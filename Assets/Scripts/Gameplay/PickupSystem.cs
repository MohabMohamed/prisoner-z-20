using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour {



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<HealthSystem>().GetHealth() < collision.gameObject.GetComponent<HealthSystem>().GetMaxHealth())
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.GetComponent<Collider2D>(), false);
                Destroy(this.gameObject);
            }
            else
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.GetComponent<Collider2D>());
        }
    }
}
