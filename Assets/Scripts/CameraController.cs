using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform CameraTarget;
    public float CameraTransSmothing;
    private Vector3 MovePoint;
	void Start () {
        MovePoint = new Vector3(CameraTarget.position.x,
            CameraTarget.position.y, transform.position.z);
        transform.position = MovePoint;

    }
	
	// Update is called once per frame
	void Update () {
        MovePoint.x = CameraTarget.position.x;
        MovePoint.y = CameraTarget.position.y;
        transform.position = Vector3.Lerp(transform.position, MovePoint, CameraTransSmothing);

    }
}
