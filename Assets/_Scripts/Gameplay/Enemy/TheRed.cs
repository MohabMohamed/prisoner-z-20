using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TheRed : Enemy {


    private new void Start () {
        base.Start();
    }
	
	
	public new void Update () {
        base.Update();
    }


    override
public void OnPlayerDied()
    {
        Debug.Log(name + " Knew that player is dead.");

        Idle();
    }

    protected override void CheckHealth()
    {
        if(healthsystem.IsDead() && !Dead)
        {
            print("bosswaveend");
            ServiceLocator.GetService<GameManager>().endWave();
        }
        base.CheckHealth();
       
    }

    protected override IEnumerator AttackCoroutine()
    {
        throw new System.NotImplementedException();
    }
}
