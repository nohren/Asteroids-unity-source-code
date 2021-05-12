using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //bool flag for playing ThemeSong
    public static bool themeSong = false;
    public static bool toggleMusic = true;
   
    void Start()
    {
        if (!themeSong && toggleMusic)
        {
            AudioManager.Play(AudioClipName.MainMenuSong);
            themeSong = true;
        }
      
        
    }
    
    public void HandlePlayButtonOnClickEvent()
    {
        MenuManager.GotoMenu(MenuName.Play);
    }
    public void HandleHelpButtonOnClickEvent()
    {
        MenuManager.GotoMenu(MenuName.Help);
    }
    public void HandleQuitButtonOnClickEvent()
    {
        MenuManager.GotoMenu(MenuName.Quit);

    }
    public void HandleMainMenuButtonOnClickEvent()
    {
        MenuManager.GotoMenu(MenuName.MainMenu);
    }

    private void Update()
    {
        if(toggleMusic && !themeSong)
        {
            AudioManager.Play(AudioClipName.MainMenuSong);
            themeSong = true;
        }
    }

    public void MusicOnOff()
    {
        AudioManager.StopClip();
        themeSong = false;
        toggleMusic = !toggleMusic;
        
    }
}
