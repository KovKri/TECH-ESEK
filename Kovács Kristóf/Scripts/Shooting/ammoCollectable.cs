using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoCollectable : MonoBehaviour
{
    public int ammoToAdd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject colGO = col.gameObject;
        if(colGO.name == "Player")
        {
            colGO.GetComponent<Shoting>().UpdateAmmo(ammoToAdd);
            Destroy(gameObject);
        }
    }
}  
