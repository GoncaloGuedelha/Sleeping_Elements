using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer
{

    public string username;
    public string password;
    public int Problem;


    public NewPlayer()
    {

        this.username = null;
        this.password = null;

    }


    public NewPlayer(string name, string pass)
    {

        this.username = name;
        this.password = pass;

    }

}
