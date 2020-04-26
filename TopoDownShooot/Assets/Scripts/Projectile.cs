using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;

    public float lifeTime;
    public GameObject explosion;
    public GameObject soundObject;
    
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        Instantiate(soundObject, transform.position, transform.rotation);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            collider.GetComponent<Enemy>().TakeDamage(damage);
            DestroyProjectile();
        }
        
        if (collider.tag == "BOSS")
        {
            collider.GetComponent<Boss>().TakeDamage(damage);
            DestroyProjectile();
        }
    }
}
