using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {

        SceneManager.LoadScene(sceneBuildIndex: 1);

    }

    public void MainMenu()
    {

        SceneManager.LoadScene(sceneBuildIndex: 0);

    }
}
