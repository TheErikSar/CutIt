using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using GameAnalyticsSDK;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
   
    private void Awake()
    {
        GameAnalytics.Initialize();
    }
    public void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }

    
}
