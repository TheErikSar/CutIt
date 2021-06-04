using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public Rigidbody trap;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "blade")
        {
            trap.useGravity = true;
        }
    }
}

