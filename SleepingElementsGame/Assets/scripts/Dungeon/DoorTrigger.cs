using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] door = new GameObject[1];
    [SerializeField] private GameObject room;
    public bool close = false;
    private bool checkEnemies;


    void Awake()
    {

        checkEnemies = false;

    }

    void Start()
    {
        
    }

    void Update()
    {

        checkEnemies = room.GetComponent<Rooms>().allDefeated;

        if (checkEnemies == true)
        {
            for (int i = 0; i < door.Length; i++)
            {

                //door[i].SetActive(false);
                door[i].GetComponent<BoxCollider2D>().isTrigger = true;
                door[i].GetComponent<Animator>().SetBool("closed", false);
                //close = false;

            }

            //close = false;
        }

        //close = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            
        if(collision.gameObject.tag == "Player")
        {

            room.SetActive(true);
                if(checkEnemies == false)
                {

                    for (int i = 0; i < door.Length; i++)
                    {

                        //door[i].SetActive(true);
                        door[i].GetComponent<Animator>().SetBool("closed", true);
                        door[i].GetComponent<BoxCollider2D>().isTrigger = false;
                        
                    //close = true;

                }

                    close = true;

                }
                
        }
       

    }
}
