﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{


    public Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<MeleeEnemyController>().TakeDamage(10, transform.position, 1);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
    
   

/*
   Could be used for magic projectile 

   public float speed;
   public float lifetime;

   //public GameObject destroyEffect;

   // Start is called before the first frame update
   private void Start()
   {
       //Invoke("DestroyProjectile", lifetime);
       Destroy(gameObject, lifetime);
   }

   // Update is called once per frame
   void Update()
   {
       transform.Translate(Vector2.right * speed * Time.deltaTime);
   }

   /* void DestroyProjectile()
   {
       Instantiate(destroyEffect, transform.position, Quaternion.identity);
       Destroy(gameObject);
   } */

