using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour {

    public Transform playerLocation;
    public float xDifference;
    public float yDifference;


    // Use this for initialization
    void Start () {
      
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = new Vector3(playerLocation.position.x + xDifference,yDifference,-29);

    }
}
