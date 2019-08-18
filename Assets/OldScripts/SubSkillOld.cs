using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSkillOld
{
    string name;
    int ranks;
    

    public SubSkillOld(string n)
    {
        this.name = n;
        this.ranks = 0;
    }
    

    public string GetName()
    {
        return this.name;
    }

    public int GetRanks()
    {
        return this.ranks;
    }

    public void AddRank(int i)
    {
        this.ranks += i;
    }

    


    
    
}
