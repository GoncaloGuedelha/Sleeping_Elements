using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCheck : MonoBehaviour
{

    public bool petConfirm;
    public GameObject petPrefab;
    private ItemBar itemBar;
    private GameObject pet;


    // Start is called before the first frame update

    void Awake()
    {

        petConfirm = GameObject.Find("PetController").GetComponent<PetToggle>().pet;
        itemBar = GameObject.FindWithTag("Itembar").GetComponent<ItemBar>();

    }

    void Start()
    {
        
        if (PetToggle.instance != null)
        {
          
          
            if(petConfirm == true)
            {

                for (int i = 0; i < itemBar.slots.Length; i++)
                {
                    if (itemBar.isFull[i] == false)
                    {
                        itemBar.isFull[i] = true;
                        pet = GameObject.Instantiate(petPrefab, itemBar.slots[i].transform, false);
                        pet.name = "Pet";
                        //shield.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                        //Debug.Log(itemBar.slots[i].transform);
                        //Destroy(gameObject);
                        /*if (gameObject.transform.parent == itemBar.slots[i].transform)
                        {

                            isChild = true;

                        }*/
                        break;

                    }


                }

            }

                     
        }


    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
