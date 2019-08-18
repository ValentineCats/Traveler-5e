using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScoreOld
{
    string name;
    int score;
    int bonus;
    int maximum;

    public AbilityScoreOld(string n)
    {
        this.name = n;
        this.score = 10;
        this.bonus = 0;
        this.maximum = 20;
    }


    //returns false if no dangerous scores
    public int IncreaseScore(int b)
    {
        if(this.score + b > this.maximum )
        {
            this.maximum += 2;
            return this.score;
        }
        else
        {
            this.score += b;
            this.CalculateBonus();
            return this.score;
        }
        
    }

    public void SetScore(int s)
    {
        this.score = s;
        this.CalculateBonus();
    }

    public int GetBonus()
    {
        return this.bonus;
    }

    public ref int GetScore()
    {
        return ref this.score;
    }

    public int GetScoreValue()
    {
        return this.score;
    }

    public string GetName()
    {
        return this.name;
    }

    public void CalculateBonus()
    {
        this.bonus = (this.score - 10) / 2;
    }


}
