using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform playerLocation;
    public float x;
    public float y;

    public float speed;

    public Transform CameraTarget;

	// Update is called once per frame
	void LateUpdate () {

        //transform.position = new Vector3(playerLocation.position.x + x,y,-29);

        transform.position = Vector3.Lerp(transform.position, new Vector3(CameraTarget.position.x, y, transform.position.z), Time.deltaTime * speed);


    }
}
