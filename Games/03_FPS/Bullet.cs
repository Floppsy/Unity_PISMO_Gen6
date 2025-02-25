﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float damage;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Skinuti health enemyu
            Enemy enemyHealth = collision.gameObject.GetComponent<Enemy>();
            enemyHealth.health -= (int)damage;
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
