using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine.UI;
public class EnemyScript : MonoBehaviour
{
    public RayFire.RayfireRigid rigid;
    public FairBariels fair;
    public GameObject blood,soul,pow;
    public GameObject Emoj;
    public Collider[] mesh;
    public Renderer col;
    public bool EnemyDead;
    public bool PlayerDead= false;
    public float Sloumo=2;
    public float Force;
    public GameObject restart;
    public float duration= 15;
    public int count;
    public float distance;
    Animator anim;
    public Transform player;
    public bool isActive=false;
    void Start()
    {
        rigid = GetComponentInChildren<RayFire.RayfireRigid>();
        fair = FindObjectOfType<FairBariels>();
        Emoj = GameObject.Find("EmojiMad");
        mesh = GetComponentsInChildren<MeshCollider>();
        col = GetComponentInChildren<Renderer>();
        EnemyDead = false;
        Time.timeScale = 1f;
        anim = GetComponent<Animator>();
        //Emoj.SetActive(false);
    }
    public virtual void ActiveEnemy()
    {
        isActive = true;
        var t = PlayerScript.MyPosition.position;
        t.y = transform.position.y;
        transform.DOMove(t, duration, false);
        anim.enabled = true;
    }
    public virtual void inFixedUpdate()
    {

    }
    void FixedUpdate()
    {

        //load = FindObjectOfType<PlayerLoadLevel>();

        if (isActive&&!EnemyDead)
        {
            inFixedUpdate();
            //Emoj.SetActive(true);

            distance = (PlayerScript.MyPosition.position - transform.position).magnitude; //Mathf.Sqrt((PlayerScript.MyPosition.position.x - transform.position.x) * (PlayerScript.MyPosition.position.x - transform.position.x) + (PlayerScript.MyPosition.position.z - transform.position.z) * (PlayerScript.MyPosition.position.z - transform.position.z));
            if (distance <2 )
            {

                anim.SetTrigger("attack");
                restart.SetActive(true);
                 DOTween.Kill(transform);
                isActive = false;
                Invoke("Playerdead",1);
            }
       
             
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "blade" || other.tag == "trap")
    //    {
    //        EnemyDead = true;
    //        col.material.color = Color.Lerp(Color.gray, Color.black, 1f);
    //        count++;
    //        Invoke("InMesh", 7f);
    //        if (count == 2)
    //        {
    //            b = true;
    //            load.enabled = true;
    //            restart.SetActive(false);
    //        }
    //        DOTween.Pause(transform.position);
    //        duration = 1000;

    //    }
      
    //}
        
    
    private void OnTriggerEnter(Collider other)
    {
        if(!EnemyDead){
            if (other.tag == "blade" || other.tag == "trap")
            {
                DOTween.Kill(transform);
                col.material.color = Color.Lerp(Color.gray, Color.black, 1f);
                print("deadenimy");
                Time.timeScale = 0.4f;
                blood.SetActive(true);
                pow.SetActive(true);
                soul.SetActive(true);
                Invoke("sloumo", 1f);
                EnemyDead = true;
                TargetPoint.countLive--;
                count++;
                Invoke("InMesh", 7f);
                if ( count == 1)
                {
                    restart.SetActive(false);

                }
            }
        }


        if(other.tag == "fair")
        {
            if (fair.faire)
            {
                rigid.Demolish();
                EnemyDead = true;
            }
        }
    }


    void sloumo()
    {
        Time.timeScale = 1f;
       
    }
    void Playerdead()
    {
        PlayerDead = true;
    }
    void InMesh()
    {
        Destroy(this.gameObject);
    }


  
}



