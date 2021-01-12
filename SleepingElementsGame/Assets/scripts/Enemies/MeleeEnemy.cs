using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    private const float waypointOffset = 0.05f;
    private const float pushForce = 3000f;

    private Rigidbody2D rb;
    private GameObject player;

    private Vector2 currentPos;
    private Vector2 playerPos;

    private string state = "Patrol";

    private float viewRange = 4f;
    private float moveSpeed = 3f;

    public float health = 2f;
    private float dmgTaken = 0f;

    [SerializeField]  private Transform[] waypoints = new Transform[1];

    private int nextWaypoint;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = new Vector2(0, 0);

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
            case "Patrol":

                if (player) {

                    //Patrolling: goes from wapoint to waypoint
                    if (Vector2.Distance(transform.position, waypoints[nextWaypoint].position) <= waypointOffset * moveSpeed)
                        nextWaypoint++;
                    if (nextWaypoint >= waypoints.Length)
                        nextWaypoint = 0;

                    transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypoint].position, moveSpeed * Time.deltaTime);

                    //Changing the state to Chase
                    if (Vector2.Distance(transform.position, player.transform.position) < viewRange)
                        state = "Chase";

                }

                break;

            case "Chase":

                if (player)
                {


                    moveSpeed = 4f;
                    
                    playerPos = new Vector2(player.transform.position.x, transform.position.y);

                    
                    transform.position = Vector2.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);

                    if (Vector2.Distance(transform.position, player.transform.position) > viewRange)
                        state = "Patrol";

                }

                else
                    state = "Patrol";

                break;

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
