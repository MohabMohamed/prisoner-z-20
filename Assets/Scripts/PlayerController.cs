using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D rg;
    Vector2 move;
    public float maxSpeed ;
    public float jumpSpeed;
    public Transform groundChecker;
    private bool facingRight;
  
    void Start () {
        rg = GetComponent<Rigidbody2D>();
        
        move = new Vector2(0, 0);
        facingRight = true;

    }
	
   
	// Update is called once per frame
	void FixedUpdate () {
        
     
        move.x = Input.GetAxis("Horizontal");
        
        Vector2 mouseInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mouseInWorld.x>transform.position.x&&!facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = true;
        }
        else if(mouseInWorld.x < transform.position.x&&facingRight)
        { 
            transform.Rotate(0, 180, 0);
            facingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)&& IsGrounded())
        {
           
            rg.AddForce(new Vector2(0, jumpSpeed));

            
        }


       
        rg.velocity = new Vector2(move.x * maxSpeed, rg.velocity.y) ;
        
        
    }
    bool IsGrounded()
    {
       // Debug.Log("Grounded");
        RaycastHit2D hit = Physics2D.Raycast(groundChecker.transform.position, -Vector3.up,0.1f);
        //  if(hit.collider != null)

        //Debug.Log(hit.collider.tag);
        // return hit.collider.CompareTag("Ground");
        Vector2 res = hit.normal;
        res.y = Mathf.Round(res.y);
        res.x = Mathf.Round(res.x);
        Debug.Log(res);
          return ( res == Vector2.up) ? true : false;
        
        //return false;
    }


}
