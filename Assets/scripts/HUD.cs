using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text timerText;

    static float elapsedSeconds = 0;

    //game timer flag
    static bool timerRunning = false;

    //set static property to grab elapsed seconds
    public static float ElapsedSeconds
    {
       get { return elapsedSeconds; } 
       set { elapsedSeconds = value; }
    }

    private void Start()
    {
        timerRunning = true;
    }
    // Update is called once per frame
    void Update()
    {

        if (timerRunning)
        {
        

            
            elapsedSeconds += Time.deltaTime;
            timerText.text = ((int)elapsedSeconds).ToString();
            
        }


    }

    public static void StopGameTimer()
    {

        timerRunning = false;
        
        
    }

}
