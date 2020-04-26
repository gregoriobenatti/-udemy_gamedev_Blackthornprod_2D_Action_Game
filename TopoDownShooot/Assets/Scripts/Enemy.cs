using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int speed;
    public float timeBetweenAttacks;
    public int damage;
    public int pickUpChange;
    public GameObject[] pickups;
    public int healthPickUpChange;
    public GameObject healthPickup;
    public GameObject deathEffect;
    public GameObject deathBloodEffect;
    
    [HideInInspector] public Transform player;


    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            var randomNumber = Random.Range(0, 101);
            if (randomNumber < pickUpChange)
            {
                var randomPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate(randomPickup, transform.position, transform.rotation);
            }
            
            var healthRandomNumber = Random.Range(0, 101);
            if (healthRandomNumber < healthPickUpChange)
            {
                Instantiate(healthPickup, transform.position, transform.rotation);
            }
            
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(deathBloodEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);   
        }
    }
}
