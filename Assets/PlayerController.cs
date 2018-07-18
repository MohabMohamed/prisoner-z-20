using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rg;
    Vector2 move;
    public float maxSpeed = 50f;
    public float jumpSpeed = 40f ;
    private bool grounded;
    private bool facingRight;
    void Start () {
        rg = GetComponent<Rigidbody2D>();
        move = new Vector2(0, 0);
        facingRight = true;
    }
	
   
	// Update is called once per frame
	void FixedUpdate () {
        move.x = Input.GetAxis("Horizontal");
        if (move.x < 0 && facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = false;
        }
        else if(move.x > 0 && !facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = true;
        }
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rg.AddForce(new Vector2(0, jumpSpeed));
            grounded = false;
        }



        rg.velocity = new Vector2(move.x * maxSpeed, rg.velocity.y) ;
        
        
    }
}
