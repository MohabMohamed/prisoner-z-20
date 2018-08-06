using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour {



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("GroundTouchTrigger"))
        {
            Destroy(this.gameObject);
        }
    }
}
