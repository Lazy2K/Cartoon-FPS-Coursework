using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericWeapon : MonoBehaviour
{
    // Changeable attributes
    [Header("Muzzle Effects")]
    public ParticleSystem muzzleFlash;
    [Header("Weapon Characteristics")]
    public bool isFullAuto;
    public float firePerSecond;

    // Private variables
    private float timeDelay;

    // Camera for raycasting
    private GameObject playerCamera;

    void Start()
    {
        playerCamera = GameObject.Find("Main Camera");
    }

    public void shoot()
    {
        
        if(Time.time > timeDelay)
        {
            // Shoot
            muzzleFlash.Play();
            timeDelay = Time.time + (1 / firePerSecond);

            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 100f))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
