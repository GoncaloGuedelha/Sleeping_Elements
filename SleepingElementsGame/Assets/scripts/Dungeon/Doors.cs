using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    // Start is called before the first frame update

    public bool isOpen;
    private BoxCollider2D openClose;
    private int enemyCount;
    public bool controlsOtherDoor;
    [SerializeField] private GameObject[] enemies = new GameObject[1];
    [SerializeField] private GameObject otherDoor;

    void Awake()
    {

        isOpen = true;
        enemyCount = -1;
    }

    void Start()
    {

        openClose = gameObject.GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        /*for (int i = 0; i < enemies.Length; i++)
            Debug.Log(i +" "+ enemies[i]);*/
        
       if (isOpen)
       {

            openClose.isTrigger = true;
            if (controlsOtherDoor)
            {

                otherDoor.GetComponent<BoxCollider2D>().isTrigger = true;

            }

       }
        else
        {

            openClose.isTrigger = false;
            if (controlsOtherDoor)
            {

                otherDoor.GetComponent<BoxCollider2D>().isTrigger = false;

            }

        }

        for(int i = 0; i < enemies.Length; i++)
        {

        //Debug.Log(enemies[i]);

            if(enemyCount == enemies.Length)
            {

                isOpen = true;

            }

            if (enemies[i] == null)
            {

                enemyCount++;
                //Debug.Log(isOpen);
                
                Debug.Log(enemyCount);

            }

            
        }



    }
}
