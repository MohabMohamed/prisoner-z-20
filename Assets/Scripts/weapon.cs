using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

	public Transform shoulder;
	private float angle;
	private Vector3 mousePosition;
	private Vector3 objectPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//...
		mousePosition = Input.mousePosition;
		mousePosition.z = 5.23f;
		objectPosition = Camera.main.WorldToScreenPoint (shoulder.position);
		mousePosition.x = mousePosition.x - objectPosition.x;
		mousePosition.y = mousePosition.y - objectPosition.y;

		angle = Mathf.Atan2 (mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

		angle += 90; //Difference between shoulder and gun
		//print (angle); //Testing

		shoulder.rotation = Quaternion.Euler (new Vector3 (0, 0, angle));
	}

	public float getAngle(){ //Is called in the flip function in playerController
		return angle;
	}
}
