using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    private GameObject weaponHolder;
    private GameObject weapon;
    private GenericWeapon weaponScript;
    private float health;

    private TMP_Text healthText;



    public GameObject grenade;
    // Start is called before the first frame update
    void Start()
    {
        weaponHolder = GameObject.Find("WeaponHolder");
        getCurrentWeapon();
        health = 1000;
        healthText = GameObject.Find("HealthPoints").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButton(0))
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

    }

    private void getCurrentWeapon()
    {
        weapon = weaponHolder.transform.GetChild(0).gameObject;
        weaponScript = weapon.GetComponent<GenericWeapon>();
    }

    public void TakeDamage()
    {
        Debug.Log(health);
        health -= 100;
        healthText.text = health + "HP";
    }
}
