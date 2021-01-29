using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{


    public string username;
    public string password;
    public int id;
    public int noNo;


    public PlayerInfo()
    {

        this.username = null;
        this.password = null;

    }


    public PlayerInfo(string name, string pass)
    {

        this.username = name;
        this.password = pass;

    }


    public PlayerInfo(int iD)
    {

        this.id = iD;

    }


}
