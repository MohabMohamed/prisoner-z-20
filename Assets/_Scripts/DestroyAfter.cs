using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour {

    public float amount;

	// Use this for initialization
	void Start () {
        //LeanTween.delayedCall(amount, () => { Destroy(gameObject); });
	}
}
