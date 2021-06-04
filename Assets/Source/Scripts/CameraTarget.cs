using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;

using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    public static List<EnemyScript> dead;
    public Transform Target;
    bool move = false;
    Vector3 v;
    Transform Next;
    public float distance;
    void Start()
    {
        v = transform.position+transform.forward;
        Target = transform;

    }
    public void settargets(EnemyScript[] d, Transform nextTarget)
    {
        print("new target");
   
        //.ToList();
        dead = (from u in d
                orderby Mathf.Sqrt(Mathf.Pow(u.transform.position.x - transform.position.x, 2) + Mathf.Pow(u.transform.position.z - transform.position.z, 2))
                select u).ToList();
        settarget(nextTarget);
    }
    public void settarget(Transform tar)
    {
        move = true;
        Next = tar;
     }



    void Update()
    {
        if (move)
        {
            //Invoke("cam", 1);

            if (dead.Count!=0)
            {
                // distance = tran
                // sform.position.z - dead[i].transform.position.z;
                if (!dead[0].EnemyDead)
                {
                    Target = dead[0].transform;
                    
                   
                }
                else
                {
                    dead.RemoveAt(0);
                }
            }
            else if(move)
            {
                Target = Next;
                //var dm = Next.position;
                //dm.y = transform.position.y;
                transform.DOMove(Next.position, 2, false);
                v = transform.forward + transform.position;
                move =  false;
            }

        }
        var t = Target.position;
        //t.y = transform.position.y;
        v = Vector3.Lerp(v, t, 0.07f);
        transform.LookAt(v);
    }




}


