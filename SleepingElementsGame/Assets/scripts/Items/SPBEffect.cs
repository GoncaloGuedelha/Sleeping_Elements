using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SPBEffect : MonoBehaviour
{
    public GameObject itemInfo;
    private float moveValue;
    private float currentSpeed;

    public int ID;
    public int oldStack;
    //public GameObject amount;
    public TextMeshProUGUI amount;

    [Range(1, 10)]
    public int maximumStack;

    void Awake()
    {

        ID = 3;
        moveValue = 1;
        maximumStack = 1;
        oldStack = maximumStack;

    }

    // Start is called before the first frame update
    void Start()
    {
        itemInfo.SetActive(false);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        //GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().shield = true;

        currentSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().moveforce;

        GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().moveforce = currentSpeed + moveValue;

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

        if (oldStack < maximumStack)
        {
            amount.text = maximumStack.ToString();
            GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().moveforce = currentSpeed + moveValue * maximumStack;

            oldStack = maximumStack;
        }
        /*checkShield = GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().shield;

        if (checkShield == false)
        {
            Destroy(gameObject);
        }*/

        /*if (maximumStack == 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().shield = false;
            Destroy(gameObject);
        }*/

    }
}
