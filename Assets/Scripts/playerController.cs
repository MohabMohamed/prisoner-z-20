using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	//Controls
	private KeyCode rightKey;
	private KeyCode leftKey;
	private KeyCode jumpKey;

	//Components
	private Rigidbody2D thisRigidBody;
	private Animator animationControl;
	private float x, y, z; //local scale
	public Transform groundChecker;
	public LayerMask ground; //What is ground is added to "Ground" layer

	//Other attributes
	private float speed; //Speed of movement
	private bool isGrounded; //Whether character is standing on ground
	private float jumpHeight;

	public GameObject bullet;
	public Transform nosel;
	private GameObject newBullet;
	public AudioClip shoot;
	public AudioClip jump;
	private AudioSource audioManager;

	// Use this for initialization
	void Start () {
		//Set controls
		this.rightKey = KeyCode.D;
		this.leftKey = KeyCode.A;
		this.jumpKey = KeyCode.Space;

		//Initializing components
		this.thisRigidBody = GetComponent<Rigidbody2D>();
		this.animationControl = GetComponent<Animator> ();
		x = transform.localScale.x;
		y = transform.localScale.y;
		z = transform.localScale.z;

		audioManager = GetComponent<AudioSource> ();

		//Default inits
		speed = 130f;
		jumpHeight = 3000f;
	}

	void FixedUpdate(){
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			newBullet = Instantiate (this.bullet, this.nosel.position, nosel.rotation);
			//newBullet.GetComponent<Rigidbody2D> ().velocity = newBullet.transform.forward * 60;
			newBullet.GetComponent<Rigidbody2D>().velocity = (Input.mousePosition - Camera.main.WorldToScreenPoint(nosel.transform.position)).normalized * 15f;
			audioManager.clip = shoot;
			audioManager.Play ();
			Destroy (newBullet, 3f);
		}
	}

	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(rightKey)){
			thisRigidBody.AddForce(Vector2.right * speed);
		}
		if (Input.GetKey (leftKey)) {
			thisRigidBody.AddForce (Vector2.left * speed);
		}

		isGrounded = Physics2D.OverlapCircle (groundChecker.position, 0.3f, ground);

		flip ();

		if (Input.GetKeyDown (jumpKey) && isGrounded) {
			thisRigidBody.AddForce (Vector2.up * jumpHeight);
			//thisRigidBody.velocity = new Vector2(thisRigidBody.velocity.x, jumpHeight);
			audioManager.clip = jump;
			audioManager.Play ();
		}


		animationControl.SetFloat ("SPEED", Mathf.Abs (thisRigidBody.velocity.x));

	}

	void flip(){
		if ((FindObjectOfType<weapon> ().getAngle () < 200 && FindObjectOfType<weapon> ().getAngle () > 0)) {
			if(thisRigidBody.velocity.x < 0)
				thisRigidBody.velocity = new Vector2(0.1f, thisRigidBody.velocity.y);
			transform.localScale = new Vector3 (x, y, z);
		}
		if ((FindObjectOfType<weapon>().getAngle() >= 200 || FindObjectOfType<weapon>().getAngle() <= 0)) {
			if(thisRigidBody.velocity.x > 0)
				thisRigidBody.velocity = new Vector2(-0.1f, thisRigidBody.velocity.y);
			transform.localScale = new Vector3 (-x, y, z);
		}
		if (thisRigidBody.velocity.x > 0) {
			transform.localScale = new Vector3 (x, y, z);
		} 
		if (thisRigidBody.velocity.x < 0) {
			transform.localScale = new Vector3 (-x, y, z);
		}
	}

}
