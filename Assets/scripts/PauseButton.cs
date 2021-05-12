using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    void Awake()
    {
       // MenuManager.GotoMenu(MenuName.Intro);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuManager.GotoMenu(MenuName.Pause);
        }
    }
}
