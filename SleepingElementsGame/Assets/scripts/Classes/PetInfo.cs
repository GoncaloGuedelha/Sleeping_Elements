using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetInfo 
{

    public int petHealthProgress;
    public int user_ID;
    public int Problem;



    public PetInfo()
    {

        this.petHealthProgress = 0;

    }


    public PetInfo(int hp, int id)
    {

        this.petHealthProgress = hp;
        this.user_ID = id;

    }

}
