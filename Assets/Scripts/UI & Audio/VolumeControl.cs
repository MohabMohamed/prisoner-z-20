using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {

    private Slider volSlider;
	// Use this for initialization
	void Start () {
        volSlider = this.gameObject.GetComponent<Slider>();
        volSlider.value = 1;
	}
	
	// Update is called once per frame
	void Update () {
        AudioListener.volume = volSlider.value;
    }
}
