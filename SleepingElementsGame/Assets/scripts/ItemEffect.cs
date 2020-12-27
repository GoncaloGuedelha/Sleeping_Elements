using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffect : MonoBehaviour
{

    public bool checkShield = false;
    public GameObject itemInfo;
    public int ID = 1;


    [Range(1, 10)]
    public int maximumStack = 1;

    // Start is called before the first frame update
    void Start()
    {
        itemInfo.SetActive(false);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().shield = true;

    }



    void OnMouseOver()
    {

        itemInfo.SetActive(true);

    }


    void OnMouseExit()
    {

        itemInfo.SetActive(false);

    }

    /* public virtual ItemEffect GetCopy()
    {


        return this;
    }

   public virtual ItemEffect Destroy()
    {



    }*/

    // Update is called once per frame
    void Update()
    {

        /*checkShield = GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().shield;

        if (checkShield == false)
        {
            Destroy(gameObject);
        }*/

        if (maximumStack == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().shield = false;
            Destroy(gameObject);
        }

    }
}
