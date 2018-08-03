using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D RIGID;
    public Camera camReference;
    HealthSystem health;
    Animator anim;


    public float maxhealth;
    public float speed;
    public float jumpheight;
    public float doublejumpheight;

    //public enum WeaponUsed {Sword, Pistol };
    public string CurrentWeapon;


    bool isGrounded = false;
    bool doubleJump = false;
    bool isLookingLeft = false;

    MeleeWeapon meleescript;
    RangedWeapon rangedscript;


    [Space]
    [Header("• Weapon References")]
    public GameObject AimingShoulder;
    public GameObject Pistol;
    public GameObject Sword;

    void Awake()
    {
        health = gameObject.AddComponent<HealthSystem>();
        health.SetMaxHealth(maxhealth);
        CurrentWeapon = "Pistol";
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
            Invoke("SetInactive", 2f);
        }

        if (CurrentWeapon.Equals("Sword"))
        {
            Pistol.SetActive(false);
            Sword.SetActive(true);
            meleescript.enabled = true;
            rangedscript.enabled = false;
            transform.Find("GunShoulder").GetComponent<LookAt>().enabled = false;

            AimingShoulder.transform.localEulerAngles = new Vector3(0,0,20);
        }
        else if(CurrentWeapon.Equals("Pistol"))
        {
            Pistol.SetActive(true);
            Sword.SetActive(false);
            meleescript.enabled = false;
            rangedscript.enabled = true;
            transform.Find("GunShoulder").GetComponent<LookAt>().enabled = true;
            
        }
        


        if (!health.IsDead())
        {
            if (isGrounded && RIGID.velocity.magnitude != 0)
            {
                anim.SetBool("Run", true);
            }
            else
                anim.SetBool("Run", false);






            // Horizontal Movement
            float moveHorizontal = Input.GetAxis("Horizontal");
            RIGID.velocity = new Vector2(moveHorizontal * speed, RIGID.velocity.y);


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

        if (other.CompareTag("Ground") || other.CompareTag("Platform"))
        {
            isGrounded = true;
            doubleJump = false;
            //print("Ground Trigger");
        }


        if (other.CompareTag("EnemySword"))
        {

            health.Damage(20);
            //RIGID.velocity = new Vector2(RIGID.velocity.x, RIGID.velocity.y + 5);

        }

        if (other.CompareTag("HealthPickup"))
        {
            health.Heal(20);
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
