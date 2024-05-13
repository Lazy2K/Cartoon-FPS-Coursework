using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    private GameObject MainMenu;
    private GameObject OptionsMenu;
    private GameObject MissionMenu;
    private GameObject MissionBrief;

    void Start()
    {
        // Reference all menu objects
        MainMenu = GameObject.Find("MainMenu");
        OptionsMenu = GameObject.Find("OptionsMenu");
        MissionMenu = GameObject.Find("MissionMenu");

        // Ensure the main menu is the first to be seen
        DisplayMainMenu();
    }

    public void QuitGame() { Application.Quit(); }

    public void DisplayOptions() {
        // Ensure all other menus are hidden
        MainMenu.SetActive(false);
        MissionMenu.SetActive(false);
        // Display main menu
        OptionsMenu.SetActive(true);
    }

    public void DisplayMainMenu() {
        // Ensure all other menus are hidden
        OptionsMenu.SetActive(false);
        MissionMenu.SetActive(false);
        // Display main menu
        MainMenu.SetActive(true);
    }

    public void DisplayMissionSelect() {
        // Ensure all other menus are hidden
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(false);
        // Display the mission select menu
        MissionMenu.SetActive(true);
    }

    public void DisplayMissionBrief(int mission) {
        if(mission == 1)
        {
            SceneManager.LoadScene("Brief01", LoadSceneMode.Single);
        }
        if (mission == 2)
        {
            SceneManager.LoadScene("Brief02", LoadSceneMode.Single);
        }
        if (mission == 3)
        {
            SceneManager.LoadScene("Brief03", LoadSceneMode.Single);
        }
    }
}
