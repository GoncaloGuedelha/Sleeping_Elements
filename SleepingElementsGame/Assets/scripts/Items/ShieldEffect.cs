using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShieldEffect : MonoBehaviour
{

    public bool checkShield = false;
    public GameObject itemInfo;
    public int ID = 1;
    public int oldStack;
    public int maxPow;
    public int effectPow;
    public TextMeshProUGUI amount;
    public bool run;

    public int maxNum = 10;
    [Range(1, 10)]
    public int maximumStack;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        itemInfo.SetActive(false);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        maxPow = 12;
        effectPow = 1;
        maximumStack = 1;
        oldStack = maximumStack;
        run = false;

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
            maxPow --;
            oldStack = maximumStack;

        }

        if (run == true) {

            effectPow = Random.Range(1, maxPow);

            if (effectPow == 1)
            {

                GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().shield = true;

            }
            else
            {

                GameObject.FindGameObjectWithTag("Player").GetComponent<playermoves>().shield = false;

            }

            run = false;

        }

        

    }
}
