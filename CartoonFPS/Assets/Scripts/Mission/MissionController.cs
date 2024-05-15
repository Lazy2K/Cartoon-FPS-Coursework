using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionController : MonoBehaviour
{
    public float levelSpecViewRange;
    public float levelSpecAttackRange;
    public float levelSpecAttackRangeDiviation;

    private Scene currentScene;
    private GameObject winScreen;

    public bool gameInPlay;

    public bool mission2done;

    private GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        winScreen = GameObject.Find("WinHUD");
        winScreen.SetActive(false);
        gameInPlay = true;

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<GenericEnemyController>().sightRange = levelSpecViewRange;
            enemy.GetComponent<GenericEnemyController>().attackRange = levelSpecAttackRange + Random.Range(0, -levelSpecAttackRangeDiviation);
        }

        if(currentScene.name == "Mission02")
        {
            mission2done = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(currentScene.name == "Mission01-02")
        {
            if(mission01objectives())
            {
                // Mission complete
                gameInPlay = false;
                winScreen.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
        if (currentScene.name == "Mission02")
        {
            if (mission02objectives())
            {
                // Mission complete
                gameInPlay = false;
                winScreen.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }

    private bool mission01objectives()
    {
        bool anyAlive = false;
        foreach(GameObject enemy in enemies)
        {
            if(enemy.GetComponent<GenericEnemyController>().isAlive)
            {
                anyAlive = true;
            }
        }
        return !anyAlive;
    }

    private bool mission02objectives()
    {
        return mission2done;
    }

    private bool mission03objectives()
    {
        return false;
    }

    public void restartMission()
    {
        if(currentScene.name == "Mission01-02") {
            SceneManager.LoadScene("Mission01-02", LoadSceneMode.Single);
        }
        if (currentScene.name == "Mission02")
        {
            SceneManager.LoadScene("Mission02", LoadSceneMode.Single);
        }
        if (currentScene.name == "Mission03")
        {
            SceneManager.LoadScene("Mission03", LoadSceneMode.Single);
        }
    }

    public void nextMission()
    {
        if (currentScene.name == "Mission01-02")
        {
            SceneManager.LoadScene("Mission02", LoadSceneMode.Single);
        }
        if (currentScene.name == "Mission02")
        {
            SceneManager.LoadScene("Mission03", LoadSceneMode.Single);
        }
        if (currentScene.name == "Mission03")
        {
            SceneManager.LoadScene("Credits", LoadSceneMode.Single);
        }
    }
}
