using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class TapToStart : MonoBehaviour
{
    public  bool p;
    public Image progressbar;
    public GameObject cam1, cam2;
    Text TapTOstart;
    public HeliCopterMove helicopter;
    public Animator anim;
    public Animator Cloud,Cloud2;
    public Animator animcam;
    PlayerLoadLevel pl;
    private void Start()
    {
        progressbar = GetComponent<Image>();
        p = false;
        TapTOstart = GetComponentInChildren<Text>();
        //animcam = GetComponent<Animator>();
        
        helicopter.enabled = false;
        pl=FindObjectOfType<PlayerLoadLevel>();
    }

    public void OnMouseDown()
    {
        Invoke("perehod", 0.5f);
        TapTOstart.enabled = false;
        //animcam = GetComponent<Animator>();
       // anim = GetComponent<Animator>();
        helicopter.enabled = false;
        //Cloud.enabled = false;
        //Cloud2.enabled = false;
        //SceneManager.LoadScene(1);
        animcam.enabled = true;
        anim.SetTrigger("start");
     
    }

    void perehod()
    {
        Analitycs.Instance.LevelStart(PlayerLoadLevel.level);
        pl.startlvl();
        //cam1.SetActive(false);
        cam2.SetActive(true);
        p = true;
        progressbar.DOFillAmount(0.5f, 1);
        gameObject.SetActive(false);
    }

}
