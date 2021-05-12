using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDestroyMenu : MonoBehaviour
{
   //send to main menu on click
   public void HandleMainMenuButtonOnClickEvent()
    {
        HUD.ElapsedSeconds = 0;
        MenuManager.GotoMenu(MenuName.MainMenu);
    }
}
