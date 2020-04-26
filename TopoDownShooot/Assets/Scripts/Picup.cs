using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picup : MonoBehaviour
{
    public Weapon weaponToEquip;
    public GameObject effect;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            collider.GetComponent<Player>().ChangeWeapon(weaponToEquip);
            Destroy(gameObject);
        }
    }
}
