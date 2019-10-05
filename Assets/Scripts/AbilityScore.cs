using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShim
{

}

public class AbilityScore 
{
    public string scoreName;
    public int score;
    public int bonus;
    public int maximum;
    //testing


    public void Initialize(string name)
    {
        this.scoreName = name;
        this.score = 10;
        this.bonus = 0;
        this.maximum = 20;
    }

    public int IncreaseScore(int b)
    {
        if (this.score + b > this.maximum)
        {
            this.maximum += 2;
            Debug.Log("Score " + this.GetName() + "'s maximum will be increased by 2 because " + (this.GetScore() + b) + " > " + this.GetMax());
            return this.score;

        }
        else
        {
            this.score += b;
            this.CalculateBonus();
            Debug.Log("Score " + this.GetName() + " " + this.score + " will be increased by " + b);
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

    public int GetScore()
    {
        return this.score;
    }

    public int GetScoreValue()
    {
        return this.score;
    }

    public string GetName()
    {
        return this.scoreName;
    }

    public int GetMax()
    {
        return this.maximum;
    }

    public void CalculateBonus()
    {
        this.bonus = (this.score - 10) / 2;
    }
}
