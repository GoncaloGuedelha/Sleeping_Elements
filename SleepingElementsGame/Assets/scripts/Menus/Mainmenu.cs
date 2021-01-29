using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public delegate void ReturningFunction(string content, int error);

public class Mainmenu : MonoBehaviour
{
    public string BaseAPI = "http://127.0.0.1:3000/";
    private List<string> playerList;
    private GameObject petControl;
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

    void Awake()
    {


    }

    void Start()
    {

        GameObject.Find("PetController").GetComponent<PetToggle>().pet = false;

    }

    public void LoginToPetSelect()
    {

        //name = "Leon";
        //pass = "Leon";

        string pData = JsonUtility.ToJson(new PlayerInfo(usernameL.text, passwordL.text));

        StartCoroutine(PostRequest(BaseAPI + "players/login", pData, LoginReceive));

        /*if (usernameL.text.ToString() == name && passwordL.text.ToString() == pass)
        {

            petSelect.SetActive(true);
            GameObject.Find("LoginScreen").SetActive(false);
           
        }
        else
        {

            lAlert.SetActive(true);

        }*/



    }

    public void LoginReceive(string rData, int error)
    {

        if(error == 0)
        {
            Debug.Log(rData);
            PlayerInfo dataReceived = JsonUtility.FromJson<PlayerInfo>(rData);
            Debug.Log(dataReceived);

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
        
            loginScreen.SetActive(true);
            GameObject.Find("RegisterScreen").SetActive(false);
        
        }



    }

    public void LoginWithPet()
    {
        GameObject.Find("PetController").GetComponent<PetToggle>().pet = true;
        petControl = GameObject.Find("PetController");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        DontDestroyOnLoad(petControl);
        

    }

    public void LoginWithoutPet()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void PlayOffline()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


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

    IEnumerator PostRequest(string uri, string jsondata, ReturningFunction FunctionName)
    {
        UnityWebRequest webRequest = new UnityWebRequest(uri, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsondata);

        webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        webRequest.SetRequestHeader("Content-Type", "application/json");

        yield return webRequest.SendWebRequest();

        if (webRequest.isNetworkError)
        {

            FunctionName(webRequest.downloadHandler.text, 1);

        }
        else
        {

            yield return webRequest.downloadHandler.text;
            FunctionName(webRequest.downloadHandler.text, 0);

        }
    }

}
