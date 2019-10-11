using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLocation
{
    string skill;
    string location;

    public StartingLocation(string s, string l)
    {
        this.skill = s;
        this.location = l;
    }



    public string GetSkill()
    {
        return this.skill;
    }

    public string GetLocation()
    {
        return this.location;
    }


    


}
