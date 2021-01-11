using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger2 : MonoBehaviour
{
    [SerializeField] private GameObject[] door = new GameObject[1];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            for (int i = 0; i < door.Length; i++)
            {

                door[i].GetComponent<Doors>().isOpen = false;

            }

        }
        else
        {
            for (int i = 0; i < door.Length; i++)
            {

            door[i].GetComponent<Doors>().isOpen = true;

            }
                

        }

    }
}
