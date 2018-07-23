using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REpeateds : MonoBehaviour {
 
    public GameObject CAMTAR;
    public float CAMspeed;

    // Use this for initialization
    void Start()
    {
        ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(CAMTAR.transform.position.x, CAMTAR.transform.position.y, CAMTAR.transform.position.z), Time.deltaTime * CAMspeed);

    }


}
