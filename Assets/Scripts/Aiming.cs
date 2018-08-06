using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour {
    public Camera mainCamera;
    // Use this for initialization
     Vector3 aimDir;
     

	
	// Update is called once per frame
	void Update () {
     
        Vector3 aimDir = mainCamera.ScreenToWorldPoint(Input.mousePosition);

       // Debug.Log(Input.mousePosition);
        aimDir = new Vector3(aimDir.x - transform.position.x, aimDir.y - transform.position.y,aimDir.z);
        transform.up =new Vector3( -aimDir.x, -aimDir.y , transform.up.z);

        Debug.Log(aimDir);

    }
}
