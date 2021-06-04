using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class striker : EnemyScript
{
    private float nextTime = 0.0F;
    private float timeRate = 1F;
    public GameObject pref;
    public Transform spawn;

    public override void ActiveEnemy()
    {
        isActive = true;
    }

    public override void inFixedUpdate()
    {   
        if (Time.time > nextTime)
        {
            nextTime = Time.time + timeRate;
            pref.transform.position = spawn.position;
            Instantiate(pref);
        }
        transform.LookAt(PlayerScript.pl.transform);
    }


}
