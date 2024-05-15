using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission02Collider : MonoBehaviour
{

    private MissionController missionController;

    // Start is called before the first frame update
    void Start()
    {
        missionController = GameObject.Find("MissionController").GetComponent<MissionController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        missionController.mission2done = true;
    }
}
