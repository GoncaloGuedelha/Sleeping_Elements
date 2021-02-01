using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo
{


    public string Username;
    public string Password;
    public int User_ID;
    public int Nono;


    public PlayerInfo()
    {

        this.Username = null;
        this.Password = null;

    }


    public PlayerInfo(string name, string pass)
    {

        this.Username = name;
        this.Password = pass;

    }


    public PlayerInfo(int iD)
    {

        this.User_ID = iD;

    }


}
