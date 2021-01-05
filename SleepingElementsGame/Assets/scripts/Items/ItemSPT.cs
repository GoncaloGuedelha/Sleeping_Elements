using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSPT : MonoBehaviour
{
    // Start is called before the first frame update

    //public bool checkShield = true;
    public bool inItem = false;
    public bool isChild = false;
    //public GameObject itemInfo;
    private ItemBar itemBar;
    private GameObject spt;
    private GameObject itemGet;
    public GameObject sptPrefab;



    public int itemID = 2;
    public int otherID = 0;

    void Start()
    {
        //itemInfo.SetActive(false);

        itemGet = GameObject.Find("Weapons/Items");
        itemBar = GameObject.FindWithTag("Itembar").GetComponent<ItemBar>();
        //GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().shield = true;

    }

    // Update is called once per frame

    /*void OnMouseOver()
    {

        itemInfo.SetActive(true);

    }


    void OnMouseExit()
    {

        itemInfo.SetActive(false);

    }*/

    void Update()
    {


        if (inItem == true && Input.GetKeyDown(KeyCode.E))
        {

            if (GameObject.Find("SPT Image") != null)
            {
                otherID = GameObject.Find("SPT Image").GetComponent<SPTEffect>().ID;
                Debug.Log(otherID);
            }
            Debug.Log(otherID);
            for (int i = 0; i < itemBar.slots.Length; i++)
            {
                if (itemBar.isFull[i] == false)
                {
                    itemBar.isFull[i] = true;
                    spt = GameObject.Instantiate(sptPrefab, itemBar.slots[i].transform, false);
                    spt.name = "SPT Image";
                    //shield.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                    //Debug.Log(itemBar.slots[i].transform);
                    Destroy(gameObject);
                    /*if (gameObject.transform.parent == itemBar.slots[i].transform)
                    {

                        isChild = true;

                    }*/
                    break;

                }
                else if (itemBar.isFull[i] == true && itemID == otherID)
                {

                    Destroy(gameObject);
                    GameObject.Find("SPT Image").GetComponent<SPTEffect>().maximumStack++;
                    break;
                }


            }

            //Debug.Log("Seven Rings");

            //gameObject.transform.parent = itemBar.transform;

            //transform.position = new Vector3(itemBar.transform.position.x - 5f,  itemBar.transform.position.y, 0f);

            //GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().shield = true;
            inItem = false;

        }

        //if (gameObject.transform.parent == slot.transform) {

        /* if(isChild == true) { 

             checkShield = true;



             checkShield = GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().shield;

             if (checkShield == false) 
             { 
                 Destroy(gameObject);
             }
         }*/
        //}


    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Speed through nights");

        if (gameObject.transform.parent == itemGet.transform && collision.gameObject.tag == "Player")
        {
            //Debug.Log("Seven Rings");
          
            gameObject.transform.parent = itemBar.transform;
            GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().shield = true; //trocar de gameobject.finnd para collision.gameobject
        }


    }*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.transform.parent == itemGet.transform && collision.gameObject.tag == "Player")
        {

            inItem = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (gameObject.transform.parent == itemGet.transform && collision.gameObject.tag == "Player")
        {

            inItem = false;
        }
    }


}
