using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFlyingEnemy : MonoBehaviour
{

    private const float waypointOffset = 0.05f;
    private const float pushForce = 3000f;
    public float health = 3f;
    private float dmgTaken = 0f;

    private Rigidbody2D rb;
    private GameObject player;
    public GameObject[] tinyOne;

    private Vector2 currentPos;
    private Vector2 playerPos;


    private float minX = 0f;
    private float maxX = 0f;
    private float minY = 0f;
    private float maxY = 0f;




    private float moveSpeed = 3f;

    [SerializeField] private Transform[] waypoints = new Transform[1];

    private int nextWaypoint;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
       


    }

    // Update is called once per frame
    void Update()
    {
        minX = transform.position.x + 2;
        maxX = transform.position.x;
        minY = transform.position.y - 2;
        maxY = transform.position.y;

        if (health <= 0)
        {

            GameObject spawnTO = Instantiate(tinyOne[0], new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);
            GameObject spawnTO2 = Instantiate(tinyOne[1], new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY)), Quaternion.identity);

            Destroy(gameObject);

        }

        //Switch Case responsible for the behaviour of the enemy
    

                if (player)
                {

                    //Patrolling: goes from wapoint to waypoint
                    if (Vector2.Distance(transform.position, waypoints[nextWaypoint].position) <= waypointOffset * moveSpeed)
                        nextWaypoint++;
                    if (nextWaypoint >= waypoints.Length)
                        nextWaypoint = 0;

                    transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypoint].position, moveSpeed * Time.deltaTime);



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