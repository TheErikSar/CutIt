using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using GameAnalyticsSDK;
public class PlayerLoadLevel : MonoBehaviour
{
    public static int level;
    public Analitycs game;
    public GameObject star;
    public Animator girl;
    public GameObject Love;
    public GameObject slade;
    public Friends f;
    public GameObject confeti, confeti2;
    public Image progress;
    public GameObject Win, nextlevel;
    public Animator anim,stars;
    public bool t;
    public EnemyScript restart, Enemy, Enemy2,Enemy3;
    public EnemyScript count;
    public Transform target,target2,target3;
    public float duration;
    public TargetPoint[] targets;
    CameraTarget camtarget;
    int indTarget=0;

    private void Awake()
    {
        count = FindObjectOfType<EnemyScript>();
    }
    void Start()
    {
        camtarget = GetComponent<CameraTarget>();
        f = FindObjectOfType<Friends>();
        t = false;
        restart = FindObjectOfType<EnemyScript>();
        Sequence Seq = DOTween.Sequence();

        //Seq.Append(transform.DOMove(target.position, duration, false));
        ////Seq.Append(transform.DORotate(new Vector3(0, 90, 0), 1, RotateMode.Fast));
        //Seq.AppendInterval(0.1f);
        //Seq.Append((transform.DOMove(target2.position, duration, false)));
        ////Seq.Append(transform.DORotate(new Vector3(0, 0, 0), 1, RotateMode.Fast));
        //Seq.AppendInterval(10f);
        //if (!f.f)
        //{
        //    Seq.Append((transform.DOMove(target3.position, duration, false)));
        //    Seq.OnComplete(Complete);
        //}
        var tar= FindObjectsOfType<TargetPoint>();
        targets = new TargetPoint[tar.Length];
        for (int i = 0; i < tar.Length; i++)
        {
            targets[tar[i].index] = tar[i];
        }
       

    }
    public void startlvl()
    {
        targets[0].SetLive();
        OnTrigerTargetPoint();
    }
    public void OnTrigerTargetPoint()
    {
        print(indTarget);
        if (targets[indTarget].TypePoint == TargetPoint.TypeTargetPoint.Entity)
        {
            camtarget.settargets(targets[indTarget].enemyInTrget, targets[indTarget + 1].transform);
        }
        else if(targets[indTarget].TypePoint==TargetPoint.TypeTargetPoint.ToMove)
        {
            camtarget.settarget(targets[indTarget + 1].transform);
        }
        if (targets[indTarget].TypePoint == TargetPoint.TypeTargetPoint.Finish)
        {
            level++;
            Invoke("Complete", 0.5f);
        }
         indTarget++;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "level1.2")
        {
          
            t = true;
            slade.SetActive(true);
            //Enemy3.enabled = true;
            //Enemy.enabled = true;
            //Enemy2.enabled = true;
         
            //anim.SetTrigger("finish");
        }
        if (other.tag == "girlemoj")
        {
            //Love.SetActive(true);
            //girl.SetTrigger("idle");
            //anim.SetTrigger("finish");
        }
    }
   
    public void Complete()
    {
        Analitycs.Instance.LevelWin(level);
        print("Победа");
        progress.DOFillAmount(10f, 2f);
        Win.SetActive(true);
        nextlevel.SetActive(true);
        confeti.SetActive(true);
        confeti2.SetActive(true);
        star.SetActive(true);
        stars.Play("Stars");
        Love.SetActive(true);
        girl.SetTrigger("idle");
        anim.SetTrigger("finish");
        //anim.SetTrigger("finish");
        PlayerPrefs.SetInt("level",level);
    }

   
}
