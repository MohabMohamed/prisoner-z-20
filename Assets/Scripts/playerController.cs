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
	public bool isGrounded; //Whether character is standing on ground
	private float jumpHeight;

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
		speed = 250f;
		jumpHeight = 15f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(rightKey)){
			thisRigidBody.AddForce(Vector2.right * speed);
		}
		if (Input.GetKey (leftKey)) {
			thisRigidBody.AddForce (Vector2.left * speed);
		}

		isGrounded = Physics2D.OverlapCircle (groundChecker.position, 1f, ground);
		flip ();

		if (Input.GetKeyDown (jumpKey) && isGrounded) {
			//thisRigidBody.AddForce (Vector2.up * jumpHeight);
			thisRigidBody.velocity = new Vector2(thisRigidBody.velocity.x, jumpHeight);
		}

		animationControl.SetFloat ("SPEED", Mathf.Abs (thisRigidBody.velocity.x));

	}

	void flip(){
		if (thisRigidBody.velocity.x > 0 || (FindObjectOfType<weapon>().getAngle() < 200 && FindObjectOfType<weapon>().getAngle() > 0)) {
			transform.localScale = new Vector3 (x, y, z);
		} else if (thisRigidBody.velocity.x < 0 || (FindObjectOfType<weapon>().getAngle() >= 200 || FindObjectOfType<weapon>().getAngle() <= 0)) {
			transform.localScale = new Vector3 (-x, y, z);
		}
	}

}
