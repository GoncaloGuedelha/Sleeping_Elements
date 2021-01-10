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
    public GameObject loginScreen;
    public GameObject lAlert;
    public GameObject rAlert;
    public GameObject rAlert2;
    public GameObject rAlert3;
    public Text usernameL;
    public Text passwordL;
    public Text usernameR;
    public Text passwordR;
    public Text passwordC;
    private string name;
    private string pass;
    //private Toggle pToggle;
    //private bool pet;

    void Awake()
    {

        //pet = false;

    }

    void Start()
    {

        GameObject.Find("PetController").GetComponent<PetToggle>().pet = false;
        //pToggle = GameObject.Find("Toggle").GetComponent<Toggle>();

    }

    public void LoginToPetSelect()
    {

        name = "Leon";
        pass = "Leon";

        if (usernameL.text.ToString() == name && passwordL.text.ToString() == pass)
        {

            //GameObject.Find("Petmenu").SetActive(true);
            petSelect.SetActive(true);
            GameObject.Find("LoginScreen").SetActive(false);
           
        }
        else
        {

            lAlert.SetActive(true);

        }



    }

    public void RegisterToLogin()
    {
        lAlert.SetActive(false);
        rAlert.SetActive(false);
        rAlert2.SetActive(false);
        rAlert3.SetActive(false);

        name = "Leon";

        if (usernameR.text.ToString() == name)
        {

            rAlert.SetActive(true);

        }
        else if(passwordR.text.ToString() != passwordC.text.ToString())
        {

            rAlert2.SetActive(true);

        }
        else if (usernameR.text.ToString() == "" || passwordR.text.ToString() == "" || passwordC.text.ToString() == "")
        {

            rAlert3.SetActive(true);

        }

        else 
        {
        
            //GameObject.Find("Petmenu").SetActive(true);
            loginScreen.SetActive(true);
            GameObject.Find("RegisterScreen").SetActive(false);
        
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

    public void DeactivateText()
    {

        lAlert.SetActive(false);
        rAlert.SetActive(false);
        rAlert2.SetActive(false);
        rAlert3.SetActive(false);

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
