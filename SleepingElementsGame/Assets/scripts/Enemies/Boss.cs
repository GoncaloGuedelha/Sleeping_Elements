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

    public GameObject secondAttackPos;
    public GameObject secondAttackPos2;
    public GameObject thirdAttackPos;
    public GameObject thirdAttackPos2;
    public GameObject thirdAttackPos3;
    private GameObject healthBar;
    

    private Vector2 playerPos;
    private Vector3 randomX;
    private Vector3 randomS;
    private Vector3 target;
    private Vector3 scaleChange;

    //Enemy main variables
    private string state = "1stStage";
    private float moveSpeed = 5f;

    //Patrol variables
    [SerializeField] private Transform[] waypoints = new Transform[1];
    private int nextWaypoint;



    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = new Vector2(0, 0);
        healthBar = GameObject.FindGameObjectWithTag("BossHealth");

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
                Destroy(healthBar);

            }

      

            //Switch Case responsible for the behaviour of the enemy
            switch (state)
            {
                case "1stStage":

                if (shootTimer <= 0)
                {

                    GameObject bullet = Instantiate(BossBullet, transform.position, Quaternion.identity);
                    Vector3 direction = target - transform.position;
                    bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;

                    shootTimer = cooldownTime;
                }

                if (shootTimer > 0)
                    shootTimer -= Time.deltaTime;

                //Changing the state to 2ndStage

                if (health <= 100)
                    state = "2ndStage";

                break;

            case "2ndStage":

                transform.position = Vector2.MoveTowards(transform.position, waypoints[nextWaypoint].position, moveSpeed * Time.deltaTime);

                cooldownTime = 0.2f;

                    if (shootTimer <= 0)
                    {

                        randomS = new Vector3(Random.Range(80.1f, 89), Random.Range(-9.3f, -8.5f), 0);

                        Vector3 direction = randomS - Camera.main.WorldToScreenPoint(transform.position);
                        direction.x += bulletStartOffset;

                        GameObject sBullet = Instantiate(BossSpecialBullet, transform.position, Quaternion.identity);


                        shootTimer = cooldownTime;
                    }

                    if (shootTimer > 0)
                        shootTimer -= Time.deltaTime;
                    //Changing the state to 3rdStage

                    if (health <= 75)
                        state = "3ndStage";

                    break;

                case "3ndStage":


                cooldownTime = 0.3f;

                if (shootTimer <= 0)
                {

                    randomX = new Vector3(Random.Range(secondAttackPos.transform.position.x, secondAttackPos2.transform.position.x), secondAttackPos.transform.position.y, 0);

                    GameObject bullet = Instantiate(BossBullet, randomX, Quaternion.identity);
                    Vector3 direction = target - randomX;
                    bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;

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
            

            dmgTaken = GameObject.FindWithTag("Bullet").GetComponent<Bullet>().dmg;

            health = health - dmgTaken;

            scaleChange = new Vector3(-dmgTaken * 10, -0, -0);
            healthBar.transform.localScale += scaleChange;
        }
    }
}