using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
using System;
using System.IO;


public class CharacterLogicContainer
{
    private List<AbilityScore> abilityScores;
    private List<Skill> skills;
    private List<StartingLocation> homelands;


    public CharacterLogicContainer()
    {
        this.abilityScores = new List<AbilityScore>();
        this.skills = new List<Skill>();
        this.homelands = new List<StartingLocation>();
    }



    public void AddSkill(string name, List<string> abilities, List<string> subskills)
    {
        List<AbilityScore> skillScores = new List<AbilityScore>();

        int abilitiesEnd = abilities.Count;
        for (int i = 0; i < abilitiesEnd; i++)
        {
            try
            {
                skillScores.Add(GetScoreByName(abilities[i]));
            }
            catch (ScoreNotFoundException ex)
            {
                throw ex;
            }
        }
        skills.Add(new Skill(name, skillScores, subskills));   //.AddSkill(name, skillScores, subskills);
    }

    public void AddAbilityScore(string name, int score)
    {
        abilityScores.Add(new AbilityScore(name, score));
    }

    

    

    public void AddHomeland(string name, string skill)
    {
        try
        {
            this.homelands.Add(new StartingLocation(name, GetSkillByName(skill)));
        }
        catch (SkillNotFoundException ex)
        {
            throw ex;
        }
        
    }

    public void RollAbilityScores(int numberOfDice, int numberOfLowestRemoved, int diceSize)
    {
        int end = this.abilityScores.Count;
        var rand = new Random();
        try
        {
            for (int i = 0; i < end; i++)
            {
                this.abilityScores[i].SetScore(RollAbilityScore(numberOfDice, numberOfLowestRemoved, diceSize, rand));

            }
        } catch(RandomRollFailed ex)
        {
            throw ex;
        }
       
    }


    private int RollAbilityScore(int numberOfDice, int numberOfLowestRemoved, int diceSize, Random rand)
    {
        if (numberOfDice <= numberOfLowestRemoved)
        {
            throw new RandomRollFailed("Error: The number of dice: " + numberOfDice + "is less than or equal to the number of dice removed: " + numberOfLowestRemoved);
        }
        if (diceSize < 1)
        {
            throw new RandomRollFailed("Error: The size of the dice being rolled: " + diceSize + "is less than 1");
        }
        if (numberOfDice < 1)
        {
            throw new RandomRollFailed("Error: Rolling " + numberOfDice + " which is less than 1");
        }

        int[] total = new int[numberOfDice];
        //rolling the dice
        for (int i = 0; i < numberOfDice; i++)
        {
            total[i] = rand.Next(1, (diceSize));
        }

        //remove the lowest dice
        int x;
        for (int i = 0; i < numberOfLowestRemoved; i++)
        {
            x = 0;
            for (int z = 0; z < numberOfDice; z++)
            {
                if (total[z] < total[x] || (total[x] == 0 && total[z] != 0))
                {
                    x = z;
                }
            }
            total[x] = 0;
        }

        int sum = 0;
        //summing up the total
        for (int i = 0; i < numberOfDice; i++)
        {
            sum += total[i];
        }

        return sum;
    }


    public void SetScoreByName(string n, int score)
    {
        try
        {
            GetScoreByName(n).SetScore(score);
        }catch(ScoreNotFoundException ex)
        {
            throw new ScoreNotFoundException(ex.Message + " while attempting to set it to " + score);
        }
        
    }

    public int GetScoreSize()
    {
        return this.abilityScores.Count;
    }


    public AbilityScore GetScoreByName(string name)
    {
        int end = this.abilityScores.Count;
        int i;
        for (i = 0; i < end; i++)
        {
            if (name.ToLower() == this.abilityScores[i].GetName().ToLower())
            {

                return this.abilityScores[i];
            }
        }
        throw new ScoreNotFoundException("Error: Unable to find score with name " + name);

    }

    public AbilityScore GetScoreByIndex(int index)
    {
        if(index < 0 || index >= this.abilityScores.Count)
        {
            throw new ScoreNotFoundException("Error: Index out of range " + index);
        }
        else
        {
            return this.abilityScores[index];
        }
    }

    public Skill GetSkillByName(string name)
    {
        int end = skills.Count;
        try
        {
            for (int i = 0; i < end; i++)
            {
                if (skills[i].GetName() == name)
                {
                    return skills[i];
                }
            }
        }
        catch (SubSkillNotFoundException ex)
        {
            throw ex;
        }
        throw new SkillNotFoundException("Error: Unable to find skill with name " + name);
    }

    public void RandomHomeland()
    {

    }

    public string GetScoresAsString()
    {
        string a = "";
        int end = abilityScores.Count;
        for (int i = 0; i < end; i++)
        {
            a += abilityScores[i].GetName() + " " + abilityScores[i].GetScore() + "\n";
        }
        return a;
    }

    public string GetSkillsAsString()
    {
        string a = "";
        int sEnd = skills.Count;
        int z;
        int ssEnd;

        for (int i = 0; i < sEnd; i++)
        {

            a += skills[i].GetName() + " " + skills[i].GetBonus() + "\n";
            ssEnd = skills[i].GetSubskills().Count;
            //Debug.Log("Displaying Skill " + s[i].GetName());
            for (z = 0; z < ssEnd; z++)
            {
                //Debug.Log("Displaying SubSkill " + s[i].subskills[z].subskillname);
                a += "  " + skills[i].GetSubskills()[z].GetSubSkillName() + " " + skills[i].GetBonus(skills[i].GetSubskills()[z].GetSubSkillName()) + "\n";
            }
            ssEnd = 0;
        }
        
        return a;
    }

    
}










[Serializable]
public class ScoreNotFoundException : Exception
{

    public ScoreNotFoundException(string danger)
        : base(danger)
    {

    }
}

[Serializable]
public class SkillNotFoundException : Exception
{

    public SkillNotFoundException(string danger)
        : base(danger)
    {

    }
}

[Serializable]
public class RandomRollFailed : Exception
{

    public RandomRollFailed(string danger)
        : base(danger)
    {

    }
}



