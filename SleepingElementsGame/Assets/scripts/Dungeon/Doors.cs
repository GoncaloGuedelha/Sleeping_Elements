using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    public bool isClosed = false;
    [SerializeField] private GameObject Trigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //isClosed = GameObject.FindWithTag("Trigger").GetComponent<DoorTrigger>().close;
        isClosed = Trigger.GetComponent<DoorTrigger>().close;

        if(isClosed = true)
        {

            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

        }
        else
        {

            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

        }
        
    }
}
