using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScores : MonoBehaviour
{
    string[] names;
    int[] scores;
    int[] maximums;
    public AbilityScore[] abilityScores;



    private void Start()
    {
        names = new string[6];
        names[0] = "str";
        names[1] = "dex";
        names[2] = "con";
        names[3] = "int";
        names[4] = "wis";
        names[5] = "cha";
       
        scores = new int[6];
        maximums = new int[6];
    }

    public int IncreaseScoreByName(string n, int i)
    {
        int x = GetScoreIntByName(n);
        if((scores[x] + i) > maximums[x])
        {
            Debug.Log("Score " + names[x] + "'s maximum will be increased by 2 because " + (scores[x] + i) + " > " + maximums[x]);
            maximums[x] += 2;
        }
        else
        {
            Debug.Log("Score " + names[x] + " " + scores[x] + " will be increased by " + i); 
            scores[x] += i;
        }
        
        return scores[x];
    }

    public string[] GetNames()
    {
        return names;
    }

    public int[] GetScores()
    {
        return scores;
    }

    public int GetBonusByName(string n)
    {
        int x = ((scores[GetScoreIntByName(n)] - 10) / 2);
        return x;
    }

    private int GetScoreIntByName(string n)
    {
        for(int i = 0; i < names.Length; i++)
        {
            if (names[i] == n)
            {
                
                return i;
            }
        }
        Debug.Log("Ability Score " + n + " not found");
        return 0;
    }


    public void SetScoreByName(string n, int i)
    {
        int x = GetScoreIntByName(n);
        scores[x] = i;
    }




    /*
    //returns false if no dangerous scores
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
    }*/
}
