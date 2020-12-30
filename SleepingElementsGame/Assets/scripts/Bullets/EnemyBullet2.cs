﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour
{

    public float speed = 5f;

    private Transform player;
    private Vector2 target;
    public float dmg = 0.5f;
    private float pCurrentHealth = 0f;

    private GameObject healthBar;
    private Vector3 scaleChange;




    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        pCurrentHealth = GameObject.FindWithTag("Player").GetComponent<playermoves>().pHealth;

        target = new Vector2(player.position.x, player.position.y);

        healthBar = GameObject.FindGameObjectWithTag("Playerhealth");
        scaleChange = new Vector3(-35f, -0, -0);

    }

    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
            Destroy(gameObject);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag != "Enemy")
        {
            //Destroy(gameObject);
             /*if (collision.CompareTag("Player")) {
                //Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        } */
         if (collision.gameObject.tag == "Player")
         {
            Debug.Log("ahahahahah");
            GameObject.FindWithTag("Player").GetComponent<playermoves>().pHealth = pCurrentHealth - dmg;
            healthBar.transform.localScale += scaleChange;
            Destroy(gameObject);

         }
         else if(collision.gameObject.tag != "Platform" && collision.gameObject.tag != "Enemy")
         {

            Destroy(gameObject);

         }
         
    }

}

