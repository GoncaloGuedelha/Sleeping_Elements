﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;

    [SerializeField] private bool isPaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            isPaused = !isPaused;

        }
        if(isPaused)
        {

            ActivateMenu();

        }
        else
        {

            DeactivateMenu();

        }
    }

    void ActivateMenu()
    {

        Time.timeScale = 0;
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

   /* public void OptionsMenu()
    {
        isPaused = false;
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);

    }*/

}
