using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject PetControl;

    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DontDestroyOnLoad(PetControl);

    }

    public void QuitGame()
    {
        Debug.Log("Quit!!");
        Application.Quit();

    }

}
