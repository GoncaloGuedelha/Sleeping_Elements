using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    private GameObject PetControl;
    //Toggle pToggle;

    void Start()
    {

        //pToggle = GameObject.Find("Toggle").GetComponent<Toggle>();

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

    /*public void PetActive()
    {
        if (pToggle.isOn)
        {

            GameObject.Find("Pet Controller").GetComponent<Pet Toggle>().pet = true;
            //Debug.Log(pet);

        }
        else
        {

            GameObject.Find("Pet Controller").GetComponent<Pet Toggle>().pet = false;
            //Debug.Log(pet);

        }*/
    

}
