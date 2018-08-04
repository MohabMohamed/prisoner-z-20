using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	Transform target;
	private float speed;
	private Rigidbody2D rb;
	private float dist;
	private float x,y,z;

	// Use this for initialization
	void Start () {
		speed = 1f;
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		rb = GetComponent<Rigidbody2D> ();
		x = transform.localScale.x;
		y = transform.localScale.y;
		z = transform.localScale.z;
	}
	
	// Update is called once per frame
	void Update () {
		dist = target.position.x - transform.position.x;
		print (dist);
		follow ();
	}

	private void follow(){
		//float dist = Vector2.Distance (target.position, transform.position);
		//Vector2 direction = (target.position - transform.position).normalized;

		if (dist > 0) {
			print (">0");
			rb.velocity = new Vector2 (speed, 0);
			transform.localScale = new Vector3 (x,y,z);
		} 
		if(dist < 0){
			print ("<0");
			rb.velocity = new Vector2 (-speed, 0);
			transform.localScale = new Vector3 (-x,y,z);
		}
	}

}
