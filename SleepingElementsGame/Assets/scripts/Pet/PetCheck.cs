using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PetCheck : MonoBehaviour
{

    public string BaseAPI = "http://127.0.0.1:3000/";
    public bool petConfirm;
    public GameObject petPrefab;
    public GameObject livingPetPrefab;
    private ItemBar itemBar;
    private GameObject pet;
    private GameObject livingPet;
    private Transform playerPos;
    private int hp = 0;
    private int usedID = 0;

    public PetInfo petInfo = new PetInfo();

    // Start is called before the first frame update

    void Awake()
    {  


    }

    void Start()
    {

        
        
        if (PetToggle.instance != null)
        {
          
          petConfirm = GameObject.Find("PetController").GetComponent<PetToggle>().pet;
          itemBar = GameObject.FindWithTag("Itembar").GetComponent<ItemBar>();
          playerPos = GameObject.FindWithTag("Player").transform;

            if(petConfirm == true)
            {
                usedID = GameObject.Find("PetController").GetComponent<PetToggle>().playerInfo.User_ID;
                Debug.Log(usedID);

                string petSendData = JsonUtility.ToJson(new PetInfo(hp, usedID));
                StartCoroutine(PetRequest(BaseAPI + "players/pet", petSendData, PetReceive));
                //livingPet = GameObject.Instantiate(livingPetPrefab, playerPos.position, Quaternion.identity);

                /*for (int i = 0; i < itemBar.slots.Length; i++)
                {
                    if (itemBar.isFull[i] == false)
                    {
                        itemBar.isFull[i] = true;
                        pet = GameObject.Instantiate(petPrefab, itemBar.slots[i].transform, false);
                        pet.name = "Pet";

                        break;

                    }


                }*/

            }

                     
        }


    }



    IEnumerator PetRequest(string uri, string jsondata, ReturningFunction FunctionName)
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

    public void PetReceive(string petData, int error)
    {

        if (error == 0)
        {
            //Debug.Log(rData);
            PetInfo petdataReceived = JsonUtility.FromJson<PetInfo>(petData);
            Debug.Log(petData);

            if (petdataReceived.Problem == 0)
            {

                livingPet = GameObject.Instantiate(livingPetPrefab, playerPos.position, Quaternion.identity);

                for (int i = 0; i < itemBar.slots.Length; i++)
                {
                    if (itemBar.isFull[i] == false)
                    {
                        itemBar.isFull[i] = true;
                        pet = GameObject.Instantiate(petPrefab, itemBar.slots[i].transform, false);
                        pet.name = "Pet";

                        break;

                    }


                }

            }
            //Debug.Log(rData);


        }
    }

}
