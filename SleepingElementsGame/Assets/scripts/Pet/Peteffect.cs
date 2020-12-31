using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peteffect : MonoBehaviour
{

    public float dmgBoost = 4f;
    public float currentDmg = 0f;
    public GameObject petInfo;
    public int ID = 0;

    // Start is called before the first frame update
    void Start()
    {

        petInfo.SetActive(false);
        currentDmg = GameObject.FindGameObjectWithTag("Gun").GetComponent<gunshoots>().dmg;


    }


    void OnMouseOver()
    {

        petInfo.SetActive(true);
     
    }


    void OnMouseExit()
    {

        petInfo.SetActive(false);

    }


    // Update is called once per frame
    void Update()
    {

        GameObject.FindGameObjectWithTag("Gun").GetComponent<gunshoots>().dmg = currentDmg + dmgBoost;
        
    }
}
