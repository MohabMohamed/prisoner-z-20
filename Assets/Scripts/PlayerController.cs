using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D RIGID;
    public float speed;
    public float jumpheight;
    public float doublejumpheight;
    HealthSystem PlayerHealth;


    bool isGrounded = false;
    bool doubleJump = false;



    void Start()
    {

        RIGID = GetComponent<Rigidbody2D>();
        PlayerHealth = new HealthSystem(RIGID, 100);

    }


    void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        RIGID.velocity = new Vector2(moveHorizontal * speed, RIGID.velocity.y);

        if (Input.GetKeyDown(KeyCode.Z))
            print(doubleJump);


        
        
        if ((Input.GetButtonDown("Jump") && isGrounded)) // Jump
        {
            RIGID.velocity = new Vector2(RIGID.velocity.x, jumpheight);  
        }
        else if (Input.GetButtonDown("Jump") && doubleJump) // Double Jump
        {
                RIGID.velocity = new Vector2(RIGID.velocity.x, doublejumpheight);
                doubleJump = false;
        }


        
       /* if (Input.mousePosition.x-0.5f*Screen.width - transform.position.x <=0)
        {
           
           transform.Rotate(new Vector3(0, 180, 0));

        }*/



    }


    void OnTriggerEnter2D(Collider2D other)
    {

       if(other.CompareTag("Ground") || other.CompareTag("Platform"))
        {
            isGrounded = true;
            doubleJump = false;
            //print("Ground Triggered");
        }



        /*
        if (other.CompareTag("Damage Block"))
        {

            PlayerHealth.Damage(20);
            RIGID.velocity = new Vector2(RIGID.velocity.x, RIGID.velocity.y + 5);

            if (PlayerHealth.GetHealth() <= 0)
            {
                RIGID.gameObject.SetActive(false);

            }
        }
        else if (other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
        }
        */
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Platform"))
        {
            isGrounded = false;
            doubleJump = true;
            //print("Ground Triggered exit");
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    }
