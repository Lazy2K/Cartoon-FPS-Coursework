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

    void Start()
    {
        
    }

    public void shoot()
    {
        
        if(Time.time > timeDelay)
        {
            // Shoot
            muzzleFlash.Play();
            timeDelay = Time.time + (1 / firePerSecond);
        }
    }
}
