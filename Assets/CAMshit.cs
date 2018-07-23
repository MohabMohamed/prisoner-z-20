using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMshit : MonoBehaviour {

    public Transform CAMTAR;
    //public GameObject CAMERA;

    public float CAMspeed;

	// Use this for initialization
	void Start () {
        ;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = CAMTAR.transform.position;
            //Vector3.Lerp(transform.position, new Vector3(CAMTAR.transform.position.x, CAMTAR.transform.position.y, CAMTAR.transform.position.z), Time.deltaTime * CAMspeed);
		
	}
}
