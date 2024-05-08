using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    private GameObject MainMenu;
    private GameObject OptionsMenu;
    private GameObject MissionMenu;

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

    public void DisplayMissionBrief(int mission) { Debug.Log("Mission brief for mission " + mission); }

    public void LoadMission01() { }
    public void LoadMission02() { }
    public void LoadMission03() { }


}
