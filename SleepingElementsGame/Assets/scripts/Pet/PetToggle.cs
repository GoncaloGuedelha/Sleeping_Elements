using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetToggle : MonoBehaviour
{

    private bool pet = false;
    Toggle pToggle;

    // Start is called before the first frame update
    void Start()
    {
        
        pToggle = GameObject.Find("Toggle").GetComponent<Toggle>();

    }

    /*public void PetCreation()
    {

        pet = Instantiate(Pet, SampleScene);
        pet.transform.parent = GameObject.Find("Itembar").transform;

    }*/

    public void PetActive()
    {
        if (pToggle.isOn)
        {

            pet = true;
            Debug.Log(pet);

        }
        else
        {

            pet = false;
            Debug.Log(pet);

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
