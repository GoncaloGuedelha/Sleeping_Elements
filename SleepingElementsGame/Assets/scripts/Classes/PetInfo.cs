using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetInfo 
{

    public int PetHealthBar;
    public int User_ID;
    public int Problem;



    public PetInfo()
    {

        this.PetHealthBar = 0;

    }


    public PetInfo(int hp, int id)
    {

        this.PetHealthBar = hp;
        this.User_ID = id;

    }

}
