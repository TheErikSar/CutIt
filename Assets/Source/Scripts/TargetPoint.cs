using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    public bool IsStartPoint=false;
    PlayerLoadLevel pl;
    public TypeTargetPoint TypePoint;
    public int index;
    public static int countLive;
    public EnemyScript[] enemyInTrget;
    BoxCollider bxc;
    bool b;
    public enum TypeTargetPoint
    {
        ToMove,
        Entity,
        Finish,
        Start
    }

    void Start()
    {
        b = true;
        pl = FindObjectOfType<PlayerLoadLevel>();
        if (!IsStartPoint)
        {
            bxc = gameObject.AddComponent<BoxCollider>();
            bxc.isTrigger = true;
        }
 



    }


    public void SetLive()
    {
        if (TypePoint == TypeTargetPoint.Entity)
        {
            countLive = enemyInTrget.Length;
            for (int i = 0; i < enemyInTrget.Length; i++)
            {
                enemyInTrget[i].ActiveEnemy();
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== "Player" && b)
        {
            print("Trigger");
            DOTween.Kill(other.transform);
            b = false;
            SetLive();
            pl.OnTrigerTargetPoint();
        }

    }
}
