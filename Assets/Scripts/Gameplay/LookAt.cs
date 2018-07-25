using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {


	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        /*Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x = transform.position.x,
            mousePosition.y = transform.position.y);

        transform.up = direction;*/


        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 90 , Vector3.forward);



    }
}
