using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private Player playerScript;

    public int healAmount;
    public GameObject effect;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            playerScript.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
