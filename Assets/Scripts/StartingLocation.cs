﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLocation
{
    Skill skill;
    string location;

    public StartingLocation(string loc, Skill sk)
    {
        this.location = loc;
        this.skill = sk;
    }



    public Skill GetSkill()
    {
        return this.skill;
    }

    public string GetLocation()
    {
        return this.location;
    }


    


}
