using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PetToggle : MonoBehaviour
{
    public PlayerInfo playerInfo = new PlayerInfo();

    public bool pet = false;
    public static PetToggle instance = null;

    // Start is called before the first frame update

    void Awake()
    {

        if(instance == null)
        {

            instance = this;

        }
        else if(instance != this)
        {

            Destroy(gameObject);

        }

    }

    void Start()
    {


    }

    void Update()
    {
        
    }
}
