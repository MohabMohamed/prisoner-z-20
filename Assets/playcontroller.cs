using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playcontroller : MonoBehaviour {

    public float speed;
    // public float threshold;
    private Rigidbody2D rb;
    public AudioSource JUMPSOUND;
    //Add empty gameobject as spawnPoint

    public float minHeightForDeath;



    public GameObject player; //Add your player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void  Update () 
    {


        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(transform.up * 200);
            JUMPSOUND.Play();
         } 
        if (Input.GetKeyDown(KeyCode.X))
        {
            Fire();
        }


      
    }
       


     
    void FixedUpdate()
    {


      
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.AddForce(movement * speed);


    }
	private void LateUpdate()
	{
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        if (mousePos.y > rb.transform.position.y)
        {
            Debug.Log("mouse x poisition is bigger then the player");

            rb.transform.eulerAngles = new Vector3(0, 180, 0);
        }
	}


    void Fire()
    {


        ;
    }






}
