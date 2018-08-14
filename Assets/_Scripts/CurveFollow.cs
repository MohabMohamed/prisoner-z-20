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

    void OnDestroy()
    {
        LeanTween.cancelAll(gameObject);
    }

    public void Move(float speed = 1 , LeanTweenType easeType = LeanTweenType.easeInSine)
    {
        LeanTween.move(gameObject ,curve.GetPointAt(0) , 0.1f).setEase(easeType).setOnComplete(()=> {
            LeanTween.value(0, 1, speed).setOnUpdate((x) => { gameObject.transform.position = curve.GetPointAt(x); });
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
