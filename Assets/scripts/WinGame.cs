using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGame : MonoBehaviour
{
    [SerializeField]
    Text DisplayTimeScore;
    string preMessage = "Score: ";
    string postMessage = " seconds";

    void Start()
    {
        Time.timeScale = 0;
        DisplayTimeScore.text = preMessage + ((int)HUD.ElapsedSeconds).ToString() + postMessage;
    }
    
    public void HandleMainButtonOnClickEvent()
    {
        HUD.ElapsedSeconds = 0;
        Destroy(gameObject);
        Time.timeScale = 1;
        MenuManager.GotoMenu(MenuName.MainMenu);
    }
}
