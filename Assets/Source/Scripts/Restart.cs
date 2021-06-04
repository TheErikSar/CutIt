using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{

    public int level;

   public  void restart()
    {
        SceneManager.LoadScene(level);
    }
}
