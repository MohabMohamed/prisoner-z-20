using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveFollow : MonoBehaviour {

    public BezierCurve curve;

    public Transform[] points;

	// Use this for initialization
	void Start () {
        //LeanTween.init(800);
        transform.position = curve.GetPointAt(0);
        // curve.res
        //Debug.Log(curve.

        Move(1);

    }


    void Move(float t)
    {
        Debug.Log(t);
        if(t > 100)
        {
            return;
        }
        LeanTween.move(gameObject, curve.GetPointAt(t / 100f), .1f).setOnComplete(() => { Move( t + 1); });
    }

    void moveDown(int index)
    {
        Debug.Log(index);
        if (index >= curve.length)
            return;
        else
            LeanTween.move(gameObject, curve.GetPointAt(index/curve.length), .5f).setOnComplete(()=> { moveDown(index + 1); });
    }
    void moveUp(int index)
    {
        if (index < 0)
            return;
        else
            LeanTween.move(gameObject, curve.GetAnchorPoints()[index].position, .5f).setOnComplete(() => { moveUp(index - 1); });
    }
	
}
