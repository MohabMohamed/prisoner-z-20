using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour {



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<HealthSystem>().GetHealth() < collision.gameObject.GetComponent<HealthSystem>().GetMaxHealth())
                Destroy(this.gameObject);
        }
    }
}
