using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour {

    // Use this for initialization
     Vector3 aimDir;
     
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        aimDir = new Vector2(Input.mousePosition.x - transform.position.x
            , Input.mousePosition.y - transform.position.y);
        
        Vector3 worldDir = Camera.main.ScreenToWorldPoint(aimDir);
        transform.up =new Vector3( -worldDir.x, -worldDir.y , transform.up.z);

    }
}
