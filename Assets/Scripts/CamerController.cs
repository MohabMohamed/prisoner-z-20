using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour {

    public Transform playerLocation;
    public float x;
    public float y;


    // Use this for initialization
    void Start () {
      
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = new Vector3(playerLocation.position.x + x,y,-29);

    }
}
