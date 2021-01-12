using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSPT : MonoBehaviour
{
    // Start is called before the first frame update

    public bool inItem = false;
    public bool isChild = false;
    private ItemBar itemBar;
    private GameObject spt;
    private GameObject itemGet;
    public GameObject sptPrefab;



    public int itemID = 2;
    public int otherID = 0;

    void Start()
    {

        itemGet = GameObject.Find("Weapons/Items");
        itemBar = GameObject.FindWithTag("Itembar").GetComponent<ItemBar>();

    }

    // Update is called once per frame


    void Update()
    {


        if (inItem == true && Input.GetKeyDown(KeyCode.E))
        {

            if (GameObject.Find("SPT Image") != null)
            {
                otherID = GameObject.Find("SPT Image").GetComponent<SPTEffect>().ID;

            }

            for (int i = 0; i < itemBar.slots.Length; i++)
            {
                if (itemBar.isFull[i] == false)
                {
                    itemBar.isFull[i] = true;
                    spt = GameObject.Instantiate(sptPrefab, itemBar.slots[i].transform, false);
                    spt.name = "SPT Image";

                    Destroy(gameObject);

                    break;

                }
                else if (itemBar.isFull[i] == true && itemID == otherID)
                {

                    Destroy(gameObject);
                    GameObject.Find("SPT Image").GetComponent<SPTEffect>().maximumStack++;
                    break;
                }


            }

            inItem = false;

        }

    }

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
