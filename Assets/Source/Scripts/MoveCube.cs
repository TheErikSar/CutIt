using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCube : MonoBehaviour
{
    public float SlouMo;
    public float distance;
    public float Force;
    public Rigidbody rb;
    bool b=true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Move(PlayerScript.lastSwipe.GetDirection(transform.forward));
        //PlayerScript.Swipe += Swipe;
    }

    //private void Swipe(Vector3 direction)
    //{
    //    var dir =  direction == Vector3.up ? Vector3.forward : direction == Vector3.down ? Vector3.back : direction;
    //    Move(direction);
    //}

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, 3);
    }

    private void Move(Vector3 direction)
    {
        
       
        rb.AddForce(  direction* Force*PlayerScript.lastSwipe.GetForce());

       // rb.AddForce(direction*PlayerScript.lastSwipe.GetForce()*Force);

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "enemy")
        {
            Destroy(gameObject);
        }
        
    }


}
