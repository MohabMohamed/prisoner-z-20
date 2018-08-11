using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {

    private Slider volSlider;
    public enum volType { Master, Music };
    public volType volumeType;
    // Use this for initialization
    void Start () {
        volSlider = this.gameObject.GetComponent<Slider>();
        volSlider.value = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if(volumeType == volType.Master)
        {
            AudioListener.volume = volSlider.value;
        }
        else if(volumeType == volType.Music)
        {
            ServiceLocator.GetService<AudioManager>().GetComponent<AudioSource>().volume = volSlider.value;
        }
        
    }
}
