using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillOld
{
    /*
    string name;
    bool proficient;
    int ranks;
    List<SubSkill> subSkills;
    AbilityScores score;

    public Skill(string n, AbilityScores s)
    {
        this.name = n;
        this.proficient = false;
        this.ranks = 0;
        this.score = s;
        subSkills = new List<SubSkill>();
    }


    public void AddRanks(int r)
    {

        int i = r;
        if(this.proficient == false)
        {
            this.proficient = true;
            i--;
        }
        if(i > 0)
        {
            ranks += r;
        }
    }

    public int GetBonus()
    {
        return this.ranks + this.score.GetBonus();
    }

    public int GetRanks()
    {
        return this.ranks;
    }

    public string GetName()
    {
        return this.name;
    }

    public int GetBonus(string s)
    {
        for(int i = 0; i < subSkills.Count; i++)
        {
            if(this.subSkills[i].GetName() == s)
            {
                return this.ranks + this.score.GetBonus() + this.subSkills[i].GetRanks();
            }
        }
        return this.ranks + this.score.GetBonus();
    }

    public void AddSubskill(string s)
    {
        SubSkill sub = new SubSkill(s);
        subSkills.Add(sub);
    }

    public static bool operator ==(Skill c1, Skill c2)
    {
        if( c1.GetName() == c2.GetName())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool operator !=(Skill c1, Skill c2)
    {
        if (c1.GetName() != c2.GetName())
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/

}
