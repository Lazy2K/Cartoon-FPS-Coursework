using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GenericWeapon : MonoBehaviour
{
    // Changeable attributes
    [Header("Muzzle Effects")]
    public ParticleSystem muzzleFlash;
    [Header("Weapon Characteristics")]
    public bool isFullAuto;
    public float firePerSecond;
    public int bulletPerMag;
    public float damage = 40f;
    public GameObject impactEffect;
    public AudioSource audioSource;

    private int currentBullets;
    private TMP_Text bulletText;

    // Private variables
    private float timeDelay;

    // Camera for raycasting
    private GameObject playerCamera;

    void Start()
    {
        playerCamera = GameObject.Find("Main Camera");
        audioSource = gameObject.GetComponent<AudioSource>();
        bulletText = GameObject.Find("BulletsText").GetComponent<TextMeshProUGUI>();
        bulletText.text = bulletPerMag + "/" + bulletPerMag;
        currentBullets = bulletPerMag;
    }

    public void shoot()
    {
        
        if(Time.time > timeDelay && currentBullets > 0)
        {
            // Shoot
            muzzleFlash.Play();
            audioSource.Play();
            timeDelay = Time.time + (1 / firePerSecond);



            RaycastHit hit;
            Vector3 targetVector = playerCamera.transform.forward;
            targetVector += transform.up * Random.Range(0.01f, -0.01f);
            targetVector += transform.right * Random.Range(0.01f, -0.01f);
            if (Physics.Raycast(playerCamera.transform.position, targetVector, out hit, 500f))
            {
                // Debug.Log(hit.transform.name);
                GenericEnemyController enemy = hit.transform.GetComponent<GenericEnemyController>();
                if(enemy != null)
                {
                    enemy.TakeDamge(damage);
                }

                GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGameObject, 2f);
            }

            currentBullets -= 1;
            bulletText.text = currentBullets + "/" + bulletPerMag;
        }
    }

    public void reload()
    {
        // Play reload sound and maybe animation
        // Refil current bullets to bullets per mag
        currentBullets = bulletPerMag;
        bulletText.text = currentBullets + "/" + bulletPerMag;
    }
}
