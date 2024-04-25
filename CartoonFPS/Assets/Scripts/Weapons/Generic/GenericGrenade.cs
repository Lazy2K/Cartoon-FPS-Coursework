using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericGrenade : MonoBehaviour
{
    public float cookTime;
    public GameObject explosionEffect;

    bool hasExploded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cookTime -= Time.deltaTime;
        if(cookTime <= 0f)
        {
            Debug.Log("Cooked off");
            Explode();
        }
    }

    void Explode()
    {
        if (!hasExploded)
        {
            hasExploded = true;
            GameObject impactGameObject = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(impactGameObject, 1f);
        } else
        {
            Destroy(gameObject);

        }
    }
}
