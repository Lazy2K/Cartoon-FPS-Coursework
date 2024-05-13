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
        MissionBrief = GameObject.Find("MissionBrief");

        // Ensure the main menu is the first to be seen
        DisplayMainMenu();
    }

    public void QuitGame() { Application.Quit(); }

    public void DisplayOptions() {
        // Ensure all other menus are hidden
        MainMenu.SetActive(false);
        MissionMenu.SetActive(false);
        MissionBrief.SetActive(false);
        // Display main menu
        OptionsMenu.SetActive(true);
    }

    public void DisplayMainMenu() {
        // Ensure all other menus are hidden
        OptionsMenu.SetActive(false);
        MissionMenu.SetActive(false);
        MissionBrief.SetActive(false);
        // Display main menu
        MainMenu.SetActive(true);
    }

    public void DisplayMissionSelect() {
        // Ensure all other menus are hidden
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(false);
        MissionBrief.SetActive(false);
        // Display the mission select menu
        MissionMenu.SetActive(true);
    }

    public void DisplayMissionBrief(int mission) {
        // Ensure all other menus are hidden
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(false);
        MissionMenu.SetActive(false);
        // Display the general mission brief
        MissionBrief.SetActive(true);
    }

    public void LoadMission01() {
        SceneManager.LoadScene("Mission01-02", LoadSceneMode.Single);
    }
    public void LoadMission02() {
        SceneManager.LoadScene("Mission02", LoadSceneMode.Single);
    }
    public void LoadMission03() { }


}
