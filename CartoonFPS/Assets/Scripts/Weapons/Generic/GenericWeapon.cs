using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericWeapon : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void shoot()
    {
        muzzleFlash.Play();
    }
}
