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
	public Transform groundChecker; //Object at feet to sheck whether player is on ground
	public LayerMask ground; //What is ground is added to "Ground" layer

	//Other attributes
	private float speed; //Speed of movement
	private bool isGrounded; //Whether character is standing on ground
	private float jumpHeight; //Jump height

	public GameObject bullet; //Bullet objects (instantiated)
	public Transform nosel; //Bullets spawn location
	private GameObject newBullet; //Temp bullet


	// Use this for initialization
	void Start () {
		//Set controls
		this.rightKey = KeyCode.D;
		this.leftKey = KeyCode.A;
		this.jumpKey = KeyCode.W;

		//Initializing components
		this.thisRigidBody = GetComponent<Rigidbody2D>();
		this.animationControl = GetComponent<Animator> ();
		x = transform.localScale.x;
		y = transform.localScale.y;
		z = transform.localScale.z;

		//Default inits
		speed = 130f;
		jumpHeight = 5000f;
	}

	void FixedUpdate(){
		if (Input.GetKeyDown (KeyCode.Mouse0)) { //Shooting
			newBullet = Instantiate (this.bullet, this.nosel.position, nosel.rotation);
			//newBullet.GetComponent<Rigidbody2D> ().velocity = newBullet.transform.forward * 60;
			newBullet.GetComponent<Rigidbody2D>().velocity = (Input.mousePosition - Camera.main.WorldToScreenPoint(nosel.transform.position)).normalized * 15f;
			FindObjectOfType<AudioManager> ().playGunSFX (); //SFX
			Destroy (newBullet, 3f);
		}
	}

	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(rightKey)){ //Walk right
			thisRigidBody.AddForce(Vector2.right * speed);
		}
		if (Input.GetKey (leftKey)) { //Walk left
			thisRigidBody.AddForce (Vector2.left * speed);
		}

		//Check whether on ground (To allow jumping)
		isGrounded = Physics2D.OverlapCircle (groundChecker.position, 0.3f, ground);
		//Check whether player sprite needs to be flipped
		flip ();

		if (Input.GetKeyDown (jumpKey) && isGrounded) { //Jump
			thisRigidBody.AddForce (Vector2.up * jumpHeight);
			//thisRigidBody.velocity = new Vector2(thisRigidBody.velocity.x, jumpHeight);
			FindObjectOfType<AudioManager>().playJumpSFX(); //SFX
		}

		//Change animations
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
