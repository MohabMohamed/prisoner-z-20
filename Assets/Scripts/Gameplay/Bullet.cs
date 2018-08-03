using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject BloodParticleFX;
    public GameObject GroundParticleFX;
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Invoke("PlayBloodFX", 0.04f);
            Destroy(this.gameObject, 0.05f);

        }
        else if (collision.CompareTag("Ground"))
        {
            Invoke("PlayGroundFX", 0.04f);
            Destroy(this.gameObject, 0.05f);

        }
    }

    private void PlayBloodFX()
    {
        GameObject particle = Instantiate(BloodParticleFX, this.transform.position, this.transform.rotation);
        Destroy(particle, 1f);
    }

    private void PlayGroundFX()
    {
        GameObject particle = Instantiate(GroundParticleFX, this.transform.position, this.transform.rotation);
        Destroy(particle, 1f);
    }

}
