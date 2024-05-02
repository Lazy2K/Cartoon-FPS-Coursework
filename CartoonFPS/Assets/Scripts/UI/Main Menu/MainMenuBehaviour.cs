using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quitting application.");
        Application.Quit();
    }
}
