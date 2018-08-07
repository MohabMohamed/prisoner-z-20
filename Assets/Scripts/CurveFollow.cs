using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveFollow : MonoBehaviour {

    public BezierCurve curve;

    public Transform[] points;

	// Use this for initialization
	void Start () {
        //LeanTween.init(800);

        // curve.res
        //Debug.Log(curve.



    }

    public void Move()
    {
        LeanTween.move(gameObject ,curve.GetPointAt(0) , 0.1f).setOnComplete(()=> {
            LeanTween.value(0, 1, 1).setOnUpdate((x) => { gameObject.transform.position = curve.GetPointAt(x); }).setEaseInSine();
        });
 }

    /*void moveDown(int index)
    {
        Debug.Log(index);
        if (index >= curve.length)
            return;
        else
            LeanTween.move(gameObject, curve.GetPointAt(index/curve.length), .1f).setOnComplete(()=> { moveDown(index + 1); });
    }
    void moveUp(int index)
    {
        if (index < 0)
            return;
        else
            LeanTween.move(gameObject, curve.GetAnchorPoints()[index].position, .1f).setOnComplete(() => { moveUp(index - 1); });
    }*/
	
}
