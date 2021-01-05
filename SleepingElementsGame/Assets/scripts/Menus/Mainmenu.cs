using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    private GameObject PetControl;
    private Toggle pToggle;

    void Awake()
    {

        GameObject.Find("PetController").GetComponent<PetToggle>().pet = false;

    }

    void Start()
    {

        pToggle = GameObject.Find("Toggle").GetComponent<Toggle>();

    }

    public void PlayGame()
    {
        PetControl = GameObject.Find("PetController");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DontDestroyOnLoad(PetControl);

    }

    public void QuitGame()
    {
        Debug.Log("Quit!!");
        Application.Quit();

    }

    public void PetActive()
    {
        if (pToggle.isOn)
        {

            GameObject.Find("PetController").GetComponent<PetToggle>().pet = true;
            //Debug.Log(pet);

        }
        else
        {

            GameObject.Find("PetController").GetComponent<PetToggle>().pet = false;
            //Debug.Log(pet);

        }


    }
}
