using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D RIGID;
    public float speed;
    public float jumpheight;
    HealthSystem PlayerHealth;


    bool isGrounded;



    void Start()
    {

        RIGID = GetComponent<Rigidbody2D>();
        PlayerHealth = new HealthSystem(RIGID, 100);

        isGrounded = false;
    }


    void LateUpdate()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        RIGID.velocity = new Vector2(moveHorizontal * speed, RIGID.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
            RIGID.velocity = new Vector2(RIGID.velocity.x, jumpheight);



    }


    void OnTriggerEnter2D(Collider2D other)
    {

       if(other.CompareTag("Ground") || other.CompareTag("Platform"))
        {
            isGrounded = true;
            print("Ground Triggered");
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
            print("Ground Triggered exit");
        }
    }

    }
