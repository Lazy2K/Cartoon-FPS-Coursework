using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private GameObject weaponHolder;
    private GameObject weapon;
    private GenericWeapon weaponScript;
    // Start is called before the first frame update
    void Start()
    {
        weaponHolder = GameObject.Find("WeaponHolder");
        getCurrentWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            weaponScript.shoot();
        }
    }

    private void getCurrentWeapon()
    {
        weapon = weaponHolder.transform.GetChild(0).gameObject;
        weaponScript = weapon.GetComponent<GenericWeapon>();
    }
}
