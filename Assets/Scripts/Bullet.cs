using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Use this for initialization
    public float destructAfter;
    public int damage;
    void Start()
    {
        Destroy(gameObject, destructAfter);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collisions)
    {
        Debug.Log("damge");
        Destroy(gameObject);

    }

}
