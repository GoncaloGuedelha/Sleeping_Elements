using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    private GameObject petControl;
    //private GameObject login;
    public GameObject petSelect;
    public Text username;
    public Text password;
    private string name;
    private string pass;
    //private Toggle pToggle;
    //private bool pet;

    void Awake()
    {

        GameObject.Find("PetController").GetComponent<PetToggle>().pet = false;
        //pet = false;

    }

    void Start()
    {

        //pToggle = GameObject.Find("Toggle").GetComponent<Toggle>();

    }

    public void LoginToPetSelect()
    {
        name = "Leon";
        pass = "Leon";

        if (username.text.ToString() == name && password.text.ToString() == pass)
        {

            //GameObject.Find("Petmenu").SetActive(true);
            petSelect.SetActive(true);
            GameObject.Find("LoginScreen").SetActive(false);
           
        }
        else
        {

            Debug.Log("NONONO");
        }



    }

    public void LoginWithPet()
    {
        GameObject.Find("PetController").GetComponent<PetToggle>().pet = true;
        //pet = true;
        petControl = GameObject.Find("PetController");
        //Debug.Log(PetControl);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DontDestroyOnLoad(petControl);
        

    }

    public void LoginWithoutPet()
    {
        //PetControl = GameObject.Find("PetController");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //DontDestroyOnLoad(PetControl);

    }

    public void PlayOffline()
    {
        //PetControl = GameObject.Find("PetController");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //DontDestroyOnLoad(PetControl);

    }

    public void QuitGame()
    {
        Debug.Log("Quit!!");
        Application.Quit();

    }

    /*public void PetActive()
    {
        if (pet)
        {

            GameObject.Find("PetController").GetComponent<PetToggle>().pet = true;
            //Debug.Log(pet);

        }
        else
        {

            GameObject.Find("PetController").GetComponent<PetToggle>().pet = false;
            //Debug.Log(pet);

        }


    }*/
}
