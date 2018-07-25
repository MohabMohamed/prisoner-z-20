using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform playerLocation;
    public float yPos;

    public float speed;

    public Transform CameraTarget;

	// Update is called once per frame
	void LateUpdate () {

        //transform.position = new Vector3(playerLocation.position.x + x,y,-29);

        transform.position = Vector3.Slerp(transform.position, new Vector3(CameraTarget.position.x, yPos, transform.position.z), Time.deltaTime * speed);


    }
}
