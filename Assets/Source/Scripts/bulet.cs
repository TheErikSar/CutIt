using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RayFire;

public class bulet : MonoBehaviour
{
   public  RayfireRigid rr;
    public Rigidbody rb;
    Vector3 v;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject,5);
        v = PlayerScript.pl.transform.position - transform.position;
        v.y--;

        //a.y--;
        //rb.AddForce((a).normalized*40);
    }
    private void FixedUpdate()
    {
  
            transform.position +=v*Time.fixedDeltaTime;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "blade")
        {
            rb.useGravity = true;
            rr.physics.useGravity = true;
        }
    }



}
