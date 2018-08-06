using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public bool isPlayerBullet = true;
    public GameObject particleFX;

	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((isPlayerBullet && collision.CompareTag("Enemy")) | collision.CompareTag("Ground") )
        {
            Invoke("GroundParticleFX", 0.04f);
            Destroy(this.gameObject, 0.05f);
            
        }
    }

    private void GroundParticleFX()
    {
        GameObject particle = Instantiate(particleFX, this.transform.position, this.transform.rotation);
        Destroy(particle, 1f);
    }
    
}
