using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SPTEffect : MonoBehaviour
{

    public GameObject itemInfo;
    private float moveValue;
    private float fireValue;
    private float currentSpeed;
    private float currentRateOfFire;

    public int ID;
    public int oldStack;
    public TextMeshProUGUI amount;

    public int maxNum = 10;
    [Range(1, 10)]
    public int maximumStack;

    void Awake()
    {

        ID = 2;
        maximumStack = 1;
        moveValue = 0.5f;
        fireValue = 0.05f;
        oldStack = maximumStack;

    }

    // Start is called before the first frame update
    void Start()
    {
        itemInfo.SetActive(false);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);

        currentSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().moveforce;
        currentRateOfFire = GameObject.FindGameObjectWithTag("Gun").GetComponent<gunshoots>().cooldownTime;

        GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().moveforce = currentSpeed - moveValue;
        GameObject.FindGameObjectWithTag("Gun").GetComponent<gunshoots>().cooldownTime = currentRateOfFire - fireValue;
    }



    void OnMouseOver()
    {

        itemInfo.SetActive(true);

    }


    void OnMouseExit()
    {

        itemInfo.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {
        if (maximumStack >= maxNum)
        {

            maximumStack = maxNum;

        }

        if (oldStack < maximumStack)
        {

            amount.text = maximumStack.ToString();

            currentSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().moveforce;
            currentRateOfFire = GameObject.FindGameObjectWithTag("Gun").GetComponent<gunshoots>().cooldownTime;

            GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().moveforce = currentSpeed - moveValue;
            GameObject.FindGameObjectWithTag("Gun").GetComponent<gunshoots>().cooldownTime = currentRateOfFire - fireValue;

            oldStack = maximumStack;

        }

    }
}


