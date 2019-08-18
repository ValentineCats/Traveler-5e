using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScore : MonoBehaviour
{
    public string scoreName;
    public int score;
    public int bonus;
    public int maximum;
    //testing


    public AbilityScore(string n)
    {
        this.scoreName = n;
        this.score = 10;
        this.bonus = 0;
        this.maximum = 20;
    }

    public int IncreaseScore(int b)
    {
        if (this.score + b > this.maximum)
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
        return this.name;
    }

    public void CalculateBonus()
    {
        this.bonus = (this.score - 10) / 2;
    }
}
