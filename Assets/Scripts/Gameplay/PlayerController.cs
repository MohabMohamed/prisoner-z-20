using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D RIGID;

    public float speed;
    public float jumpheight;
    public float doublejumpheight;

    public Camera camReference;

    HealthSystem healthsystem;


    bool isGrounded = false;
    bool doubleJump = false;

    
    bool isLookingLeft;


    void Start()
    {

        RIGID = GetComponent<Rigidbody2D>();
        this.gameObject.AddComponent<HealthSystem>();
        healthsystem = this.gameObject.GetComponent<HealthSystem>();

        if(camReference == null)
            camReference = ServiceLocator.GetService<CameraController>().GetComponent<Camera>();

        isLookingLeft = false;





    }



    void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        RIGID.velocity = new Vector2(moveHorizontal * speed, RIGID.velocity.y);



        // Jump
        if (! ServiceLocator.GetService<GameManager>().IsPaused())
        {
            if ((Input.GetButtonDown("Jump") && isGrounded))
            {
                RIGID.velocity = new Vector2(RIGID.velocity.x, jumpheight);
                ServiceLocator.GetService<AudioManager>().PlayJumpSFX();
            }
            else if (Input.GetButtonDown("Jump") && doubleJump) // Double Jump
            {
                RIGID.velocity = new Vector2(RIGID.velocity.x, doublejumpheight);
                doubleJump = false;
                ServiceLocator.GetService<AudioManager>().PlayJumpSFX();
            }

            CheckFlip();
        }

     

        
                
    }

    void CheckFlip()
    {
        if (!isLookingLeft && Input.mousePosition.x <= camReference.WorldToScreenPoint(transform.position).x)
        {
            //print("Flip Left , LocalScale " + transform.localScale);
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);

            isLookingLeft = true;
        }
        else if (isLookingLeft && Input.mousePosition.x > camReference.WorldToScreenPoint(transform.position).x)
        {
            //print("Flip Right , LocalScale " + transform.localScale);
            transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, transform.localScale.z);

            isLookingLeft = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Ground") || other.CompareTag("Platform"))
        {
            isGrounded = true;
            doubleJump = false;
            //print("Ground Trigger");
        }




        if (other.CompareTag("Enemy"))
        {

            healthsystem.Damage(20);
            RIGID.velocity = new Vector2(RIGID.velocity.x, RIGID.velocity.y + 5);

            if (healthsystem.GetHealth() <= 0)
            {
                RIGID.gameObject.SetActive(false);

            }
        }

        if (other.CompareTag("HealthPickup"))
        {
            healthsystem.Heal(20);
        }


        }


    void OnTriggerExit2D(Collider2D other)
    {


        if (other.CompareTag("Ground") || other.CompareTag("Platform"))
        {
            isGrounded = false;
            doubleJump = true;
            //print("Ground Trigger exit");
        }


    }

    public float GetSpeed()
    {
        return speed;
    }

    public bool IsLookingLeft()
    {
        return isLookingLeft;
    }
}
