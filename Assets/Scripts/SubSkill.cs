using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSkill : MonoBehaviour
{

    public string subskillname;
    public int ranks;
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
    
    public string getSubSkillName()
    {
        return this.subskillname;
    }

    public int getRanks()
    {
        return this.ranks;
    }

    public void Rank(int i)
    {
        this.ranks += i;
        if(this.ranks < 0)
        {
            this.ranks = 0;
        }
    }

    public void Rank(int i, int max)
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
