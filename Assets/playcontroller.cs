using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playcontroller : MonoBehaviour {

    public float speed;
   // public float threshold;
    private Rigidbody2D rb;

      public Transform spawnPoint;//Add empty gameobject as spawnPoint
    public float minHeightForDeath;
    public GameObject player; //Add your player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void  Update () 
    {
          if (Input.GetKeyDown ("space")){
                  transform.Translate(Vector2.up * 260 * Time.deltaTime, Space.World);
          } 


    
        if (player.transform.position.y < minHeightForDeath)
            player.transform.position = spawnPoint.position;
 } 
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(movement * speed);

        //if (transform.position.y < threshold)
            //transform.position = new Vector3(0, 0, 0);
    }


   
 

         
}
