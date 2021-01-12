using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShield : MonoBehaviour
{
    // Start is called before the first frame update

    public bool inItem = false;
    public bool isChild = false;
    private ItemBar itemBar;
    private GameObject shield;
    private GameObject itemGet;
    public GameObject shieldPrefab;



    public int itemID = 1;
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

            if (GameObject.Find("Shield Image") != null)
            {
                otherID = GameObject.Find("Shield Image").GetComponent<ShieldEffect>().ID;

            }

            for (int i = 0; i < itemBar.slots.Length; i++)
            {
                if (itemBar.isFull[i] == false)
                {
                    itemBar.isFull[i] = true;
                    shield = GameObject.Instantiate(shieldPrefab, itemBar.slots[i].transform, false);
                    shield.name = "Shield Image";

                    Destroy(gameObject);

                    break;

                }
                else if (itemBar.isFull[i] == true && itemID == otherID)
                {

                    Destroy(gameObject);
                    GameObject.Find("Shield Image").GetComponent<ShieldEffect>().maximumStack++;
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
