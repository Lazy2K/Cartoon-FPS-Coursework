using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionController : MonoBehaviour
{
    private Scene currentScene;

    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentScene.name == "Mission01-02")
        {
            if(mission01objectives())
            {
                // Mission complete
                Debug.Log("All enemies dead");
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
        return false;
    }

    private bool mission03objectives()
    {
        return false;
    }
}
