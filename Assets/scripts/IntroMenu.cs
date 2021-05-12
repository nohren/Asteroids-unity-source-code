using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMenu : MonoBehaviour
{

    void Start()
    {
       
        Time.timeScale = 0;
        AudioManager.Play(AudioClipName.HyperdriveTrouble);
    }


   
    public void HandleOnClickEventResume()
    {
        
        Time.timeScale = 1;
        AudioManager.Play(AudioClipName.FalconFlyBy);
        Destroy(gameObject);
    }
          
}
        
    
