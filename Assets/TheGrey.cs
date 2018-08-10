using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TheGrey : Enemy
{


    private new void Start()
    {
        base.Start();
    }


    public new void Update()
    {
        base.Update();
    }


    override
public void OnPlayerDied()
    {
        Debug.Log(name + " Knew that player is dead.");

        StopMoving();
    }


    void StopMoving()
    {
        anim.SetBool("Run", false);
    }

    protected override IEnumerator AttackCoroutine()
    {
        throw new System.NotImplementedException();
    }
}
