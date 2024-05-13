using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BriefController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void playMission(int missionNumber)
    {
        if(missionNumber == 1)
        {
            Debug.Log("Button Clicked");
            SceneManager.LoadScene("Mission01-02", LoadSceneMode.Single);
        }
        if (missionNumber == 2)
        {
            SceneManager.LoadScene("Mission02", LoadSceneMode.Single);
        }
        if (missionNumber == 3)
        {
            SceneManager.LoadScene("Mission03", LoadSceneMode.Single);
        }
    }

    public void home()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }
}
