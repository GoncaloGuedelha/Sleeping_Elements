using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peteffect : MonoBehaviour
{

    public float dmgBoost = 2f;
    public GameObject petInfo;
    //public int ID = 0;
    public int hp = 0;

    public PetInfo petInf = new PetInfo();

    // Start is called before the first frame update
    void Start()
    {

        petInfo.SetActive(false);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
        hp = petInf.PetHealthBar;
        Debug.Log("Health" + hp);


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

        
    }
}
