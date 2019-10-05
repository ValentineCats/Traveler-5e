using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityScores : MonoBehaviour
{
    //string[] names;
    //int[] scores;
    //int[] maximums;
    public List<AbilityScore> abilityScores;
    //public GameObject abilityScoreContainerObject;

    AbilityScores()
    {
        abilityScores = new List<AbilityScore>();
    }


    public void AddAbilityScore(string name)
    {
        // this.gameObject.transform.GetChild(0).gameObject.AddComponent<AbilityScore>();
       // GameObject o = Instantiate(abilityScoreContainerObject, new Vector3(0,0,0), Quaternion.identity);
        //o.transform.parent = this.gameObject.transform;

        //o.GetComponent<AbilityShim>().Initialize(n);
        AbilityScore abilityScore = new AbilityScore();
        abilityScore.Initialize(name);
        abilityScores.Add(abilityScore);
    }

    public int IncreaseScoreByName(string n, int sco)
    {
        this.GetListLocName(n).IncreaseScore(sco);
        return this.GetListLocName(n).GetScore();
    }

    

    public int GetBonusByName(string n)
    {
          return GetListLocName(n).GetBonus();
       
        
    }



    private int GetScoreIntByName(string n)
    {
        return GetListLocName(n).GetScore();
    }

    //utility that find the score by name. Used by many other methods
    private AbilityScore GetListLocName(string n)
    {
        int end = this.abilityScores.Count;
        int i;
        for (i = 0; i < end; i++)
        {
            if (n == this.abilityScores[i].GetName())
            {
               
                return this.abilityScores[i];
            }
        }

        Debug.Log("Ability Score " + n + " not found");
        return this.abilityScores[0];
    }


    public void SetScoreByName(string n, int sco)
    {
        GetListLocName(n).SetScore(sco);
        Debug.Log("Ability Score " + n + " not found");
    }

    public List<AbilityScore> GetScores()
    {
        return this.abilityScores;
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
