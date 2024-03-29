﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSkill
{

    private string subskillname;
    private int ranks;
    //public Skill skill;

    public SubSkill(string n)
    {
        this.subskillname = n.ToLower();
        this.ranks = 0;
    }

    /*
    void Start()
    {
        
        this.subskillname = this.name.ToLower();
        if (this.name.ToLower() != this.subskillname)
        {
            Debug.Log("Names unequal " + this.name + " " + this.subskillname);
        }
        
    }*/
    
    public string GetSubSkillName()
    {
        return this.subskillname;
    }

    public int GetRanks()
    {
        return this.ranks;
    }

    public void AddRank(int i)
    {
        this.ranks += i;
        if(this.ranks < 0)
        {
            this.ranks = 0;
        }
    }

    public void AddRank(int i, int max)
    {
        if(max >= this.ranks)
        {
            return;
        }

        this.ranks += i;
        if (this.ranks < 0)
        {
            this.ranks = 0;
        }
    }


}
