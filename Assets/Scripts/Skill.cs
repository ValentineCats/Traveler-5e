using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string skillname;
    public bool proficient;
    public int ranks;
    public SubSkill[] subskills;
    public AbilityScore score;



    private void Start()
    {
        this.skillname = this.name.ToLower();
        if (this.name.ToLower() != this.skillname)
        {
            Debug.Log("Names unequal " + this.name + " " + this.skillname);
        }
        subskills = this.GetComponentsInChildren<SubSkill>();
        
    }

    public Skill(string n, AbilityScore s, string[] ss)
    {
        this.skillname = n;
        this.proficient = false;
        this.ranks = 0;
        this.score = s;
        for(int i = 0; i < ss.Length; i++)
        {
            this.AddSubskill(ss[i]);
        }
    }

    public Skill(string n, AbilityScore s)
    {
        this.skillname = n;
        this.proficient = false;
        this.ranks = 0;
        this.score = s;
        
    }


    public void AddRanks(int r)
    {

        int i = r;
        if (this.proficient == false)
        {
            this.proficient = true;
            i--;
        }
        if (i > 0)
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
        return this.skillname;
    }

    public int GetBonus(string s)
    {
        /*
        if (this.subskills.ContainsKey(s))
        {
            if (this.proficient)
            {
                return this.ranks + this.score.GetBonus() + (int)this.subskills[s];
            }
        }
        else if(this.proficient)
        {
            return this.ranks + this.score.GetBonus();
            
        }
        return this.score.GetBonus() - 2;*/
        return 0;
    }

    public void AddSubskill(string s)
    {
        //subskills.Add(s, 0);

    }
    /*
    public static bool operator ==(Skill c1, Skill c2)
    {
        if (c1.GetName() == c2.GetName())
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
