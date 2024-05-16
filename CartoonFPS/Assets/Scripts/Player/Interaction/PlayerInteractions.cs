using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class PlayerInteractions : MonoBehaviour
{
    private GameObject weaponHolder;
    private GameObject weapon;
    private GenericWeapon weaponScript;
    private float health;

    private PostProcessVolume fxVolume;
    private Vignette fxVignette;
    private float vignetteIntensity;

    public AudioClip playerGruntSFX;
    public AudioClip fleshHitSFX;
    public AudioClip bulletNearMissSFX;

    public AudioSource audioSource;

    public bool isDead;

    private GameObject hud;
    private GameObject deadScreen;

    private TMP_Text healthText;

    // Camera for raycasting
    private GameObject playerCamera;

    private int weaponLayer;

    private MissionController missionControl;


    public GameObject grenade;
    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.Find("Main Camera");
        weaponHolder = GameObject.Find("WeaponHolder");
        getCurrentWeapon();
        weapon.GetComponent<Rigidbody>().isKinematic = true; // Dissable physics on currently heald weapon
        Physics.IgnoreCollision(weapon.GetComponent<Collider>(), GetComponent<Collider>());
        health = 1000;
        healthText = GameObject.Find("HealthPoints").GetComponent<TextMeshProUGUI>();
        weaponLayer = LayerMask.NameToLayer("Weapon");
        isDead = false;
        hud = GameObject.Find("PlayerHUD");
        deadScreen = GameObject.Find("DeathHUD");
        deadScreen.SetActive(false);

        audioSource = gameObject.GetComponent<AudioSource>();

        fxVolume = GameObject.Find("CameraEffects").GetComponent<PostProcessVolume>();
        fxVolume.profile.TryGetSettings<Vignette>(out fxVignette);

        missionControl = GameObject.Find("MissionController").GetComponent<MissionController>();

        if(!fxVignette)
        {
            Debug.Log("Error getting vinitee");
        }

        vignetteIntensity = 0f;
        fxVignette.enabled.Override(true);
        fxVignette.intensity.Override(vignetteIntensity);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButton(0) && !isDead && missionControl.gameInPlay)
        {
            weaponScript.shoot();
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            GameObject grenadeObject = Instantiate(grenade, weapon.transform.position, Quaternion.identity);
            grenadeObject.GetComponent<Rigidbody>().AddForce((transform.forward) * 10f);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            weaponScript.reload();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            tryGetWeapon();
        }

        checkIsDead();
        StartCoroutine(runDamageEffect());
        fxVignette.intensity.Override(vignetteIntensity);
    }

    private void checkIsDead()
    {
        if(health <= 0)
        {
            // Player is dead so do the things that need to be done
            // Hide hud
            // Dissable player input
            // Show death screen
            isDead = true;
            hud.SetActive(false);
            deadScreen.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            missionControl.gameInPlay = false;
        }
    }

    private void getCurrentWeapon()
    {
        weapon = weaponHolder.transform.GetChild(0).gameObject;
        weaponScript = weapon.GetComponent<GenericWeapon>();
        weaponScript.updateBulletText();
    }

    public void TakeDamage()
    {
        Debug.Log(health);
        health -= 25;
        healthText.text = health + "HP";
        audioSource.PlayOneShot(fleshHitSFX, 1f);
        audioSource.PlayOneShot(playerGruntSFX, 1f);
        vignetteIntensity = 1f;
    }

    private void tryGetWeapon()
    {
        RaycastHit hit;
        Vector3 targetVector = playerCamera.transform.forward;
        if (Physics.Raycast(playerCamera.transform.position, targetVector, out hit, 5f))
        {
            Debug.Log(hit.collider.gameObject.name);
            if(hit.collider.gameObject.layer == weaponLayer)
            {
                // Found a weapon that wants to be taken
                weapon.transform.SetParent(null, true);
                weapon.GetComponent<Rigidbody>().isKinematic = false;
                // Unparent and drop current weapon
                // Parent new weapon and move it to local vector 0,0,0 with correct rotation
                hit.collider.gameObject.transform.SetParent(weaponHolder.transform);
                getCurrentWeapon();
                Physics.IgnoreCollision(weapon.GetComponent<Collider>(), GetComponent<Collider>());
                weapon.GetComponent<Rigidbody>().isKinematic = true;
                weapon.transform.localPosition = new Vector3(0, 0, 0);
                weapon.transform.localRotation = Quaternion.identity;
                weapon.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);



            }
        }
    }

    private IEnumerator runDamageEffect()
    {
        while(vignetteIntensity > 0)
        {
            vignetteIntensity -= 0.01f;
            if (vignetteIntensity < 0) vignetteIntensity = 0;
            yield return new WaitForSeconds(0.1f);
        }
        yield break;
    }

}
