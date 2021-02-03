using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject exitMenu;

    [SerializeField] private bool isPaused;
    private bool isStopped;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isStopped == false)
        {

            isPaused = !isPaused;
            ActivateMenu();

        }

        else if(Input.GetKeyDown(KeyCode.Escape) && isStopped == true)
        {

            ActivateMenu();
            CloseOptionsMenu();
            CancelExit();

        }

        if (isPaused)
        {

            Time.timeScale = 0;

        }
        else
        {

            DeactivateMenu();

        }
    }

    void ActivateMenu()
    {

        AudioListener.pause = true;
        pauseMenu.SetActive(true);

    }

    public void DeactivateMenu()
    {

        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void PreviousScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    public void QuitGame()
    {

        isStopped = true;
        AudioListener.pause = true;
        pauseMenu.SetActive(false);
        exitMenu.SetActive(true);

    }

     public void OptionsMenu()
     {

         isStopped = true;
         AudioListener.pause = true;
         pauseMenu.SetActive(false);
         optionsMenu.SetActive(true);

     }

    public void CloseOptionsMenu()
    {

        isStopped = false;
        AudioListener.pause = true;
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);

    }


    public void ExitConfirm()
    {

        Debug.Log("Quit!!");
        Application.Quit();

    }

    public void CancelExit()
    {

        isStopped = false;
        AudioListener.pause = true;
        pauseMenu.SetActive(true);
        exitMenu.SetActive(false);

    }

}
