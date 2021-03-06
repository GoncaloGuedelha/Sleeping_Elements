﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleFlyingEnemy : MonoBehaviour
{

    private const float waypointOffset = 0.05f;
    private const float pushForce = 3000f;
    public float health = 0.5f;
    private float dmgTaken = 0f;

    private Rigidbody2D rb;
    private GameObject player;

    private Vector2 currentPos;
    private Vector2 playerPos;

    private string state = "Watch";

    private float viewRange = 10f;
    private float moveSpeed = 3f;

    [SerializeField] private Transform[] waypoints = new Transform[1];

    private int nextWaypoint;

    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = new Vector2(0, 0);

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {

            Destroy(gameObject);

        }

        //Switch Case responsible for the behaviour of the enemy
        switch (state)
        {
            case "Watch":

                if (player)
                {

                   

                    //Changing the state to Chase
                    if (Vector2.Distance(transform.position, player.transform.position) < viewRange)
                        state = "Chase";

                }

                break;

            case "Chase":

                if (player)
                {


                    moveSpeed = 5f;

                    playerPos = new Vector2(player.transform.position.x, player.transform.position.y);


                    transform.position = Vector2.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);

                    Vector2 pDir = player.transform.position - transform.position;
                    pDir.Normalize();

                    if ((pDir.x < 0) && (spriteRenderer.flipX))
                    {

                        spriteRenderer.flipX = false;

                    }
                    else if ((pDir.x > 0) && (!spriteRenderer.flipX))
                    {

                        spriteRenderer.flipX = true;

                    }

                    if (Vector2.Distance(transform.position, player.transform.position) > viewRange)
                        state = "Watch";

                }

                else
                    state = "Watch";

                break;

        }

        if ((rb.velocity.x < 0) && (spriteRenderer.flipX))
        {

            spriteRenderer.flipX = false;

        }
        else if ((rb.velocity.x > 0) && (!spriteRenderer.flipX))
        {

            spriteRenderer.flipX = true;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {

            dmgTaken = GameObject.FindWithTag("Bullet").GetComponent<Bullet>().dmg;

            health = health - dmgTaken;

        }
    }

}