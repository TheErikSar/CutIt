using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairBariels : MonoBehaviour
{
    
    public RayFire.RayfireRigid rigid,rigid2;
    public GameObject explosion;
    public bool faire=false;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "blade")
        {
            rigid.GetComponentInParent<EnemyScript>().EnemyDead = true;
            rigid2.GetComponentInParent<EnemyScript>().EnemyDead = true;
            explosion.SetActive(true);
            faire = true;
            rigid.Demolish();
            rigid2.Demolish();
        }

      
    }
}
