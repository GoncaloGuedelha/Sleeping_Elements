using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingPet : MonoBehaviour
{

    private const float waypointOffset = 0.05f;


    private Rigidbody2D rb;
    private GameObject player;

    private Vector2 currentPos;
    private Vector2 playerPos;


    private float moveSpeed = 5f;




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

        //Switch Case responsible for the behaviour of the enemy



                    playerPos = new Vector2(player.transform.position.x, player.transform.position.y);


                    transform.position = Vector2.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
                    //Debug.Log("Player Position: " + playerPos + "\n" +
                    //"Enemy Position: " + transform.position);



        

    }



}