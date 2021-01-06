using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private const float waypointOffset = 0.05f;

    private Rigidbody2D rb;
    private GameObject player;

    [SerializeField] public GameObject BossBullet;
    [SerializeField] public GameObject BossSpecialBullet;
    private GameObject bullet;
    private float bulletStartOffset = 0.5f;
    private float shootTimer = 0f;
    private float cooldownTime = 1f;
    public float health = 150f;
    public float speed = 5f;
    private float dmgTaken = 0f;
    public bool triggered = false;

    private Vector2 playerPos;
    private Vector3 randomX;
    private Vector3 randomS;
    private Vector3 target;

    //Enemy main variables
    private string state = "1stStage";
    //private float viewRange = 5f;
    private float moveSpeed = 3f;

    //Patrol variables
    [SerializeField] private Transform[] waypoints = new Transform[1];
    private int nextWaypoint;

    //Keeping the distance

    //private float retreatDist = 3f;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = new Vector2(0, 0);



        rb.gravityScale = 0;

    }

    void Update()
    {
        target = new Vector2(player.transform.position.x, player.transform.position.y);

        if (triggered)
        {

            playerPos = player.transform.position;
            if (health <= 0)
            {

                Destroy(gameObject);

            }

            //Patrolling: goes from wapoint to waypoint
            //if (Vector2.Distance(transform.position, waypoints[nextWaypoint].position) <= waypointOffset * moveSpeed)
                //nextWaypoint++;

            /*if (nextWaypoint >= waypoints.Length)
                nextWaypoint = 0;*/

        

            //Switch Case responsible for the behaviour of the enemy
            switch (state)
            {
                case "1stStage":

                /*//Patrolling: goes from wapoint to waypoint
                if (Vector2.Distance(transform.position, waypoints[nextWaypoint].position) <= waypointOffset * moveSpeed)
                    nextWaypoint++;

                if (nextWaypoint >= waypoints.Length)
                    nextWaypoint = 0;

                transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypoint].position, moveSpeed * Time.deltaTime);*/



                //Changing the state to Chase

                if (shootTimer <= 0)
                {

                    GameObject bullet = Instantiate(BossBullet, transform.position, Quaternion.identity);
                    Vector3 direction = target - transform.position;
                    bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;

                    shootTimer = cooldownTime;
                }

                if (shootTimer > 0)
                    shootTimer -= Time.deltaTime;


                if (health <= 100)
                    state = "2ndStage";

                break;

            case "2ndStage":

                /* //Patrolling: goes from wapoint to waypoint
                 if (Vector2.Distance(transform.position, waypoints[nextWaypoint].position) <= waypointOffset * moveSpeed)
                     nextWaypoint++;

                 if (nextWaypoint >= waypoints.Length)
                     nextWaypoint = 0;

                 transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypoint].position, moveSpeed * Time.deltaTime);*/

                transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypoint].position, moveSpeed * Time.deltaTime);

                cooldownTime = 0.5f;

                if (shootTimer <= 0)
                {

                    randomX = new Vector3(Random.Range(62, 79), 2, 0);

                    GameObject bullet = Instantiate(BossBullet, randomX, Quaternion.identity);
                    Vector3 direction = target - randomX;
                    bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;

                        shootTimer = cooldownTime;
                }

                if (shootTimer > 0)
                    shootTimer -= Time.deltaTime;



                    /* else if(Vector2.Distance(transform.position, playerPos) < viewRange  && Vector2.Distance(transform.position, playerPos) > retreatDist) {

                         transform.position = this.transform.position;

                     }*/


                    /*if (Vector2.Distance(transform.position, player.transform.position) > viewRange)
                    {

                        transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypoint].position, moveSpeed * Time.deltaTime);
                        state = "Patrol";
                    }*/

                    if (health <= 50)
                        state = "3ndStage";

                    break;

                case "3ndStage":

                    /* //Patrolling: goes from wapoint to waypoint
                     if (Vector2.Distance(transform.position, waypoints[nextWaypoint].position) <= waypointOffset * moveSpeed)
                         nextWaypoint++;

                     if (nextWaypoint >= waypoints.Length)
                         nextWaypoint = 0;

                     transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypoint].position, moveSpeed * Time.deltaTime);*/

                    //transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypoint].position, moveSpeed * Time.deltaTime);

                    cooldownTime = 0.1f;

                    if (shootTimer <= 0)
                    {

                        randomS = new Vector3(Random.Range(62, 79), Random.Range(-7, -5), 0);

                        Vector3 direction = randomS - Camera.main.WorldToScreenPoint(transform.position);
                        direction.x += bulletStartOffset;

                        GameObject sBullet = Instantiate(BossSpecialBullet, transform.position, Quaternion.identity);

                        /*randomS = new Vector3(Random.Range(-89.5f, -72), Random.Range(5, 7), 0);

                        GameObject bullet = Instantiate(BossSpecialBullet, transform.position, Quaternion.identity);
                        Vector3 direction = randomS - transform.position;
                        bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;*/

                        shootTimer = cooldownTime;
                    }

                    if (shootTimer > 0)
                        shootTimer -= Time.deltaTime;

                    break;
            }

            
        }   
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Bullet" && triggered)
        {

            dmgTaken = GameObject.FindWithTag("Gun").GetComponent<gunshoots>().dmg;

            health = health - dmgTaken;

        }
    }
}