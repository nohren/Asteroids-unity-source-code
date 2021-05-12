using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager 
{
   public static void GotoMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Play:
                //start gameplay scene
                SceneManager.LoadScene("GamePlay");
                break;
            case MenuName.Help:
                //start help menu
                SceneManager.LoadScene("HelpMenu");
                break;
            case MenuName.Quit:
                //quit exe
                Application.Quit();
                break;
            case MenuName.MainMenu:
                //go to MainMenu
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case MenuName.ShipDestroyed:
                Object.Instantiate(Resources.Load("ShipDestroy"));
                break;
            case MenuName.WinGame:
                Object.Instantiate(Resources.Load("WinGame"));
                break;
            case MenuName.Intro:
                Object.Instantiate(Resources.Load("Intro"));
                break;
                
        }
    }
}
