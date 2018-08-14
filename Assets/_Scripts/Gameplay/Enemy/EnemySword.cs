using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySword : MonoBehaviour {

    public UnityEvent OnSwordHitThePlayer;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            OnSwordHitThePlayer.Invoke();
        }
    }


}// end class
