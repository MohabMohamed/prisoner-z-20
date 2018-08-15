
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform playerLocation;
    public float yPos;
    public float zPos;
    public float speed;

/*
    public float leftBoundary;
    public float rightBoundary;
    public Transform CameraTarget;
    */
    public Transform CameraTarget;
    public Transform leftBoundary;
    public Transform rightBoundary;

    public float leftBoundaryDiff;
    public float rightBoundaryDiff;

    private bool shaking = false;

	// Update is called once per frame
	void LateUpdate () {

        //transform.position = new Vector3(playerLocation.position.x + x,y,-29);

        
        if( !shaking&&!(transform.position.x < leftBoundary.position.x + leftBoundaryDiff) | !(transform.position.x > rightBoundary.position.x + rightBoundaryDiff) )
            transform.position = Vector3.Slerp(transform.position, new Vector3(CameraTarget.position.x, yPos, zPos), Time.deltaTime * speed);
        
        if(!shaking && transform.position.x < leftBoundary.position.x + leftBoundaryDiff)
        {
            //transform.position = new Vector3(leftBoundary , transform.position.y, zPos);
            transform.position = Vector3.Slerp(transform.position, new Vector3(leftBoundary.position.x + leftBoundaryDiff, yPos, zPos), Time.deltaTime * speed);
        } else if(!shaking && transform.position.x > rightBoundary.position.x + rightBoundaryDiff)
        {
            //transform.position = new Vector3(rightBoundary , transform.position.y, zPos);
            transform.position = Vector3.Slerp(transform.position, new Vector3(rightBoundary.position.x + rightBoundaryDiff, yPos, zPos), Time.deltaTime * speed);
        }



    }

   public IEnumerator Shake(float duration, float magnitude)
    {
        shaking = true;
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float x = Random.Range(-1.0f, 1.0f) * magnitude+originalPos.x;
            float y = Random.Range(-1.0f, 1.0f) * magnitude+originalPos.y;
            transform.localPosition = new Vector3(x, y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
        shaking = false;
    }

}
