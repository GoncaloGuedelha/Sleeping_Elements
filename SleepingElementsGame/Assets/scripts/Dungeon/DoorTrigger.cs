using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] door = new GameObject[1];
    [SerializeField] private GameObject room;
    private bool checkEnemies;

    // Start is called before the first frame update

    void Awake()
    {

        checkEnemies = false;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        checkEnemies = room.GetComponent<Rooms>().allDefeated;

        if (checkEnemies == true)
        {
            for (int i = 0; i < door.Length; i++)
            {

                door[i].GetComponent<BoxCollider2D>().isTrigger = true;

            }


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(checkEnemies);
            
        if(collision.gameObject.tag == "Player")
        {

                if(checkEnemies == false)
                {

                    for (int i = 0; i < door.Length; i++)
                    {

                        door[i].GetComponent<BoxCollider2D>().isTrigger = false;

                    }

                }
                
        }
       

    }
}
