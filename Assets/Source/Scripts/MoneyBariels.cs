using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyBariels : MonoBehaviour
{

    public GameObject money;
    public Text mon;
    public int moneta;

    public void Update()
    {

        mon.text = moneta.ToString();
        PlayerPrefs.SetInt("",moneta);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "blade")
        {
            money.SetActive(true);
            moneta += 200;
            
        }
    }
}
