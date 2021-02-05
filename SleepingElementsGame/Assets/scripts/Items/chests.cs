using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chests : MonoBehaviour
{

    public bool open = false;

    private GameObject player;
    private GameObject weaponsItemsHolder;
    public GameObject[] theSelector;
    private int index;
    private GameObject selected;
    private GameObject drop;
    private bool playerInside = false;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindWithTag("Player");
        weaponsItemsHolder = GameObject.Find("Weapons/Items");

        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if(playerInside == true && Input.GetKeyDown(KeyCode.E))
        {

            if (!open)
            {
                index = Random.Range(0, theSelector.Length);
                selected = theSelector[index];

                open = true;
                animator.SetBool("open", true);
                GameObject create = Instantiate(selected, transform.position, Quaternion.identity) as GameObject;
                create.transform.parent = weaponsItemsHolder.transform;

            }
            else
            {

                animator.SetBool("open", false);

            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            playerInside = false;
        }
    }

}

