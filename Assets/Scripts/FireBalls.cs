using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBalls : MonoBehaviour {

	 public Bullet fireBall;
    public float fireBallSpeed;
    public Transform player;
    private const float gravityAcc = 9.8f;
    private float horzintalDist;
    private float theta;
    void Start () {
        
        InvokeRepeating("Fire", 1.0f, 0.5f);
    }
	
	// Update is called once per frame

  

    void Fire()
    {
        horzintalDist = player.position.x - transform.position.x;


        //theta = Mathf.Asin(Mathf.Deg2Rad*(horzintalDist * gravityAcc) /fireBallSpeed*fireBallSpeed )/2;
        //Debug.Log(theta);
        //Vector2 direction = new Vector2(Mathf.Cos(theta), Mathf.Sin(theta));
        //Bullet clone = (Bullet)Instantiate(fireBall, transform.position,Quaternion.identity);
        //clone.GetComponent<Rigidbody2D>().AddForce(direction * fireBallSpeed,ForceMode2D.Impulse);
        
    }
    void OnDestroy()
    {
        CancelInvoke();
    }
}
