using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToItems : MonoBehaviour
{
    
    private GameObject pos;
    private Vector3 oldPos;
    private bool isIn;


    void Awake()
    {

        isIn = false;

    }

    void Start()
    {
        
    }

    void Update()
    {
        pos = GameObject.FindWithTag("Player");

        if(Input.GetKeyUp("i") && isIn == false)
        {
            oldPos = pos.transform.position;
            pos.transform.position = new Vector3(-25.7f, -19.5f, 0);
            isIn = true;

        }
        else if(Input.GetKeyUp("i") && isIn == true)
        {

            pos.transform.position = new Vector3(oldPos.x, oldPos.y, 0);
            isIn = false;

        }

        if (Input.GetKeyUp("b"))
        {

            pos.transform.position = new Vector3(229.7f, -26f, 0);

        }

        if (Input.GetKeyUp("h"))
        {

            GameObject.FindWithTag("Player").GetComponent<playermoves>().pHealth = 99999999999999999999999f;
            GameObject.Find("bar").GetComponent<SpriteRenderer>().color = Color.yellow;
        }

    }
}
