using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skill
{
    public string skillname;
    public bool proficient;
    public int ranks;
    public List<SubSkill> subskills;
    public List<AbilityScore> scores;


    /*
    private void Start()
    {
        
        this.skillname = this.name.ToLower();
        if (this.name.ToLower() != this.skillname)
        {
            Debug.Log("Names unequal " + this.name + " " + this.skillname);
        }
        subskills = this.GetComponentsInChildren<SubSkill>();
        
}*/

    public Skill(string n, List<AbilityScore> ab, List<string> ss)
    {
        this.skillname = n;
        this.proficient = false;
        this.ranks = 0;
        this.scores = ab;
        this.subskills = new List<SubSkill>();

        int ssEnd = ss.Count;
        for(int i = 0; i < ssEnd; i++)
        {
            this.AddSubskill(ss[i]);
        }
    }

    public Skill(string n, List<AbilityScore> ab)
    {
        this.skillname = n;
        this.proficient = false;
        this.ranks = 0;
        this.scores = ab;
        this.subskills = null;
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
    public void AddSubSkillRanks(string s, int r)
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
        
        try
        {
            if (this.proficient == false)
            {
                return this.ranks + this.ChooseScore().GetBonus() - 2;
            }
            else
            {
                return this.ranks + this.ChooseScore().GetBonus();
            }
        }
        catch (SubSkillNotFoundException ex)
        {
            throw ex;
        }
    }

    public int GetBonus(string s)
    {
        try
        {
            if (this.proficient == false)
            {
                return this.ranks + GetSubskillListLocName(s).GetRanks() + this.ChooseScore().GetBonus() - 2;
            }
            else
            {
                return this.ranks + GetSubskillListLocName(s).GetRanks() + this.ChooseScore().GetBonus();
            }
        }
        catch(SubSkillNotFoundException ex)
        {
            throw ex;
        }
        

    }

    private AbilityScore ChooseScore()
    {
        int end = this.scores.Count;
        int max = 0;
        for(int i = 0; i < end; i++)
        {
            if(this.scores[i].GetBonus() > this.scores[max].GetBonus())
            {
                max = i;
            }
        }
        return this.scores[max];
    }

    public int GetRanks()
    {
        return this.ranks;
    }

    public string GetName()
    {
        return this.skillname;
    }

    private SubSkill GetSubskillListLocName(string name)
    {
        int end = this.subskills.Count;
        int i;
        for (i = 0; i < end; i++)
        {
            if (name == this.subskills[i].GetSubSkillName())
            {

                return this.subskills[i];
            }
        }
        throw new SubSkillNotFoundException("Unable to find subskill with name " + name);
    }

   

    public void AddSubskill(string n)
    {
        SubSkill sub = new SubSkill(n);
        subskills.Add(sub);

    }
    
}

[Serializable]
public class SubSkillNotFoundException : Exception
{

    public SubSkillNotFoundException(string danger)
        : base(danger)
    {

    }
}