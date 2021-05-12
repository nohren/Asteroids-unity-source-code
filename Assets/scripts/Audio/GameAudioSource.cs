using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An audio source for the entire game
/// </summary>
public class GameAudioSource : MonoBehaviour
{

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    /// 


    



    void Awake()
    {

        //make sure we have only one of this GameObject in the game.  So we call before the game starts
        if (!AudioManager.Initialized)
        {
            //initialize audio manager and persist audio source across all scenes
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Initialize(audioSource);
            DontDestroyOnLoad(gameObject); //get the audioSource across all scenes
        }
        else
        {
            //duplicate game object, so destroy
            Destroy(gameObject); //if it already exists, then shouldn't it not need to be fucked with?
        }
    }
   
  

}
