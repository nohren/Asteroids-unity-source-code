using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }
    public void HandleResumeButtonOnClickEvent()
    {
        //unpause game, destroy menu object
        Time.timeScale = 1;
        Destroy(gameObject);
    }
    public void HandleQuitButtonOnClickEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GotoMenu(MenuName.MainMenu);
    }
  


}
