using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D RIGID;
    public Camera camReference;
    HealthSystem health;
    Animator anim;
    bool isGrounded = false;
    bool doubleJump = false;
    bool isLookingLeft = false;
    [HideInInspector]
    public bool isPlayerOnPlatform;


    public float maxhealth;
    public float speed;
    public float jumpheight;
    public float doublejumpheight;

    

    

    [Space]
    [Header("• Weapons Related")]
    //public enum WeaponUsed {Sword, Pistol };
    public string CurrentWeapon;
    public GameObject AimingShoulder;
    public GameObject Pistol;
    public GameObject Sword;

    MeleeWeapon meleescript;
    RangedWeapon rangedscript;

    [HideInInspector]
    public bool FiringAllowed { get; set; }

    void Awake()
    {
        health = gameObject.AddComponent<HealthSystem>();
        health.SetMaxHealth(maxhealth);
        CurrentWeapon = "Pistol";
        FiringAllowed = true;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        RIGID = GetComponent<Rigidbody2D>();

        meleescript = GetComponent<MeleeWeapon>();
        rangedscript = GetComponent<RangedWeapon>();

        if (camReference == null)
            camReference = ServiceLocator.GetService<CameraController>().GetComponent<Camera>();


    }



    void Update()
    {
        if (health.IsDead())
        {
    
            anim.SetTrigger("Died");
        }


        if (CurrentWeapon.Equals("Sword"))
        {
            Pistol.SetActive(false);
            Sword.SetActive(true);
            meleescript.enabled = true;
            rangedscript.enabled = false;
            AimingShoulder.GetComponent<LookAt>().enabled = false;

            AimingShoulder.transform.localEulerAngles = new Vector3(0,0,20);
        }
        else if(CurrentWeapon.Equals("Pistol"))
        {
            Pistol.SetActive(true);
            Sword.SetActive(false);
            meleescript.enabled = false;
            rangedscript.enabled = true;
            AimingShoulder.GetComponent<LookAt>().enabled = true;
            
        }
        


        Move();



    }

    void Move()
    {
        if (!health.IsDead())
        {
            /*
            if (isGrounded && RIGID.velocity.magnitude != 0)
            {
                anim.SetBool("Run", true);
            }
            else
                anim.SetBool("Run", false);
                */






            // Horizontal Movement
            if(Input.GetAxis("Horizontal") != 0)
            {
                float moveHorizontal = Input.GetAxis("Horizontal");
                RIGID.velocity = new Vector2(moveHorizontal * speed, RIGID.velocity.y);
                anim.SetBool("Run", true);
            }
            else
                anim.SetBool("Run", false);

            // Jump
            if (!ServiceLocator.GetService<GameManager>().IsPaused())
            {
                if (Input.GetButtonDown("Jump"))
                    Jump();

                CheckFlip();
            }

        }
    }

    void Jump()
    {
        if (isGrounded)
        { 
            RIGID.velocity = new Vector2(RIGID.velocity.x, jumpheight);
            ServiceLocator.GetService<AudioManager>().PlayJumpSFX();
            anim.SetBool("Run", false);

            isGrounded = false;
            doubleJump = true;
        }
        else if (doubleJump)
        {
            RIGID.velocity = new Vector2(RIGID.velocity.x, doublejumpheight);
            doubleJump = false;
            ServiceLocator.GetService<AudioManager>().PlayJumpSFX();
            anim.SetBool("Run", false);
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

        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            doubleJump = false;
        } 
        else if (other.CompareTag("Platform"))
        {
            isGrounded = true;
            doubleJump = false;
            isPlayerOnPlatform = true;
        }
        if (other.CompareTag("HealthPickup"))
        {
            health.Heal(20);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            isPlayerOnPlatform = false;
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
    public void ChangeWeapon(string NewWeapon)
    {
        CurrentWeapon = NewWeapon;
    }
    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
    
}
