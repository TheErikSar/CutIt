using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Friends : MonoBehaviour
{
    public Renderer col;
    public bool f=false;
    public GameObject Restart;
    public GameObject lose;

    private void Start()
    {
        col = GetComponentInChildren<Renderer>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "blade")
        {
            f = true;
            col.material.color = Color.black;
            lose.SetActive(true);
            Invoke("IsLoad", 2);

        }
    }
    void IsLoad()
    {
        SceneManager.LoadScene(0);
        Restart.SetActive(true);
    }
}
