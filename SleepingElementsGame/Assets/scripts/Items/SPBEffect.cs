﻿using System.Collections;
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
    public TextMeshProUGUI amount;

    public int maxNum = 10;
    [Range(1, 10)]
    public int maximumStack;

    private Animator animator;

    void Awake()
    {

        ID = 3;
        maximumStack = 1;
        moveValue = 1;
        oldStack = maximumStack;

    }

    // Start is called before the first frame update
    void Start()
    {
        itemInfo.SetActive(false);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);

        currentSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().moveforce;

        GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().moveforce = currentSpeed + moveValue;

        animator = GetComponent<Animator>();

    }



    void OnMouseOver()
    {

        itemInfo.SetActive(true);
        animator.SetBool("Anim", true);

    }


    void OnMouseExit()
    {

        itemInfo.SetActive(false);
        animator.SetBool("Anim", false);

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

            GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().moveforce = currentSpeed + moveValue;

            oldStack = maximumStack;
        }

    }
}
