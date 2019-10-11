﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Newtonsoft.Json;


public class SkillTest
{
    public string name { get; set; }
    public List<string> score { get; set; }
    public List<string> subskills { get; set; }
}

public class SkillsJson
{
    public List<SkillTest> skillTest { get; set; }
}

public class AbilityScoresJson
{
    public List<string> abilityScores { get; set; }
}


public class Homeland
{
    public string home { get; set; }
    public string skill { get; set; }
}

public class HomelandsJson
{
    public List<Homeland> homelands { get; set; }
}


public class GameLogic : MonoBehaviour
{
    
    public AbilityScores abilityscores;
    public Skills skills;
    public List<StartingLocation> startinglocations; 
    public Text displayscores;
    public Text displayskills;
    public Button[] buttons;

    private string skillsJsonPath;
    private string abilityScoresJsonPath;
    private string homelandJsonPath;
    private SkillsJson skillsJson;
    private AbilityScoresJson abilityScoresJson;
    private HomelandsJson homelandsJson;


    // Start is called before the first frame update
    void Start()
    {
        skillsJsonPath = "Assets/Resources/SkillsJson.json";
        abilityScoresJsonPath = "Assets/Resources/AbilityScoresJson.json";
        homelandJsonPath = "Assets/Resources/HomelandsJson.json";
        var skilljson = File.ReadAllText(skillsJsonPath);
        var abilscorejson = File.ReadAllText(abilityScoresJsonPath);
        var homelandsjson = File.ReadAllText(homelandJsonPath);
        skillsJson = JsonConvert.DeserializeObject<SkillsJson>(skilljson);
        abilityScoresJson = JsonConvert.DeserializeObject<AbilityScoresJson>(abilscorejson);
        homelandsJson = JsonConvert.DeserializeObject<HomelandsJson>(homelandsjson);





        InitializeAbilityScores();
        InitializeSkills();
        InitializeHomeland();

        this.ChooseHome();
        this.StageOne();
        DisplayScores();
        DisplaySkills();

    }

    //This rolls the scores
    private void RollAbilityScores()
    {
        int end = abilityscores.abilityScores.Count;
        for (int i = 0; i < end; i++)
        {
            abilityscores.SetScoreByName(abilityscores.GetScores()[i].GetName(), RandomRoll(3, 0, 6));
            Debug.Log("Score: " + abilityscores.abilityScores[i].GetName() + ". Total: " + abilityscores.GetScores()[i].GetScore());
        }
        DisplayScores();
    }
    
    //This populates the ability scores
    private void InitializeAbilityScores()
    {
        int end = abilityScoresJson.abilityScores.Count;
        for (int i = 0; i < end; i++)
        {
            abilityscores.AddAbilityScore(abilityScoresJson.abilityScores[i]);
            Debug.Log("Initialized score: " + abilityScoresJson.abilityScores[i]);
        }
        this.RollAbilityScores();
        DisplayScores();

    }

    private void InitializeSkills()
    {
        int skillEnd = skillsJson.skillTest.Count;
        List<AbilityScore> abs;
        int absEnd;
        SkillTest skl;
        int ssEnd;
        List<string> sskl;
        int i,z,x;



        for(i = 0; i < skillEnd; i++)
        {
            skl = skillsJson.skillTest[i];
            abs = new List<AbilityScore>();
            sskl = new List<string>();
            //skl.subskills = skillsJson.skillTest[i].subskills;
            absEnd = skl.score.Count;
            for (z = 0; z < absEnd; z++)
            {
                abs.Add(abilityscores.GetListLocName(skl.score[z]));
            }
            if(skl.subskills != null)
            {
                ssEnd = skl.subskills.Count;
                for (x = 0; x < ssEnd; x++)
                {
                    sskl.Add(skl.subskills[x]);
                }
            }
            else
            {
                sskl = new List<string>();
            }
            
            skills.AddSkill(skillsJson.skillTest[i].name, abs, sskl);
        }
    }

    private void InitializeHomeland()
    {
        this.startinglocations = new List<StartingLocation>();
        int end = this.homelandsJson.homelands.Count;
        StartingLocation star;
        for (int i = 0; i < end; i++)
        {
            star = new StartingLocation(this.homelandsJson.homelands[i].home, this.homelandsJson.homelands[i].skill);
        }
    }


    private int RandomRoll(int numberOfDice, int numberOfLowestRemoved, int diceSize)
    {
        if(numberOfDice <= numberOfLowestRemoved)
        {
            Debug.Log("Removing more dice than are being rolled");
            return 0;
        }
        if(diceSize < 1)
        {
            Debug.Log("Rolling dice of size 0 or lower");
            return 0;
        }
        if(numberOfDice < 1)
        {
            Debug.Log("Rolling 0 or fewer dice");
            return 0;
        }

        int[] total = new int[numberOfDice];
        //rolling the dice
        for (int i = 0; i < numberOfDice; i++)
        {
            total[i] = Random.Range(1, (diceSize + 1));
            Debug.Log("Rolled: " + total[i]);
        }

        //remove the lowest dice
        int x;
        for (int i = 0; i < numberOfLowestRemoved; i++)
        {
            x = 0;
            for(int z = 0; z < numberOfDice; z++)
            {
                if (total[z] < total[x] || (total[x] == 0 && total[z] != 0))
                {
                    Debug.Log(total[z] + " is less than " + total[x] + ", or " + total[x] + " eqauls 0 and " + total[z] + "does not equal 0");
                    x = z;
                }
            }
            total[x] = 0;
        }

        int sum = 0;
        //summing up the total
        for(int i = 0; i < numberOfDice; i++)
        {
            sum += total[i];
        }

        return sum;
    }

    private void DisplayScores()
    {
        List<AbilityScore> s = abilityscores.GetScores();

        string a = "";
        int end = s.Count;
        for(int i = 0; i < end; i++)
        {
            a += s[i].GetName() + " " + s[i].GetScore() + "\n";
        }
        this.displayscores.text = a;
    }

    private void DisplaySkills()
    {
        List<Skill> s = skills.skills;
        string a = "";

        int sEnd = s.Count;
        int z;
        int ssEnd;
        Debug.Log("Displaying Skills");
        for(int i = 0; i < sEnd; i++)
        {

            a += s[i].GetName() + " " + s[i].GetRanks() + "\n";
            ssEnd = s[i].subskills.Count;
            Debug.Log("Displaying Skill " + s[i].GetName());
            for (z = 0; z < ssEnd; z++)
            {
                Debug.Log("Displaying SubSkill " + s[i].subskills[z].subskillname);
                a += "  " + s[i].subskills[z].subskillname + " " + s[i].subskills[z].ranks + "\n";
            }
        }
        this.displayskills.text = a;

    }

    private void StageOne()
    {
        this.DisplayScores();
        this.SetAbilityScoreChoiceButtons();
    }

    private void SetAbilityScoreChoiceButtons()
    {
        
        List<AbilityScore> s = abilityscores.GetScores();
        Text t;

        int end = s.Count;
        for (int i = 0; i < end; i++)
        {
            t = this.buttons[i].GetComponentInChildren<Text>();
            t.text = s[i].GetName();
            int ac = i;
            AbilityScore[] ad = abilityscores.GetScores().ToArray();
            //List<AbilityScore> ad = abilityscores.GetScores();
            this.buttons[i].onClick.AddListener(() => ReplaceScores(ref ad[ac]));
        }
        t = this.buttons[end].GetComponentInChildren<Text>();
        t.text = "None";

    }

    private void ReplaceScores(ref AbilityScore a)
    {
        a.SetScore(14);
        this.DisplayScores();
        for (int i = 0; i < this.buttons.Length; i++)
        {
            this.buttons[i].gameObject.SetActive(false);
        }
    }


    private void ChooseHome()
    {
        int roll = Random.Range(0, this.startinglocations.Count); ;
        if(roll > 0)
        {
            this.skills.GetSkill(this.startinglocations[roll].GetSkill()).AddRanks(1);
            Debug.Log(this.startinglocations[roll].GetSkill() + " " + this.startinglocations[roll].GetType());
        }
    }





    /*

    private void InitializeSkills()
    {
        Skill[] a = new Skill[30];
        a[0] = new Skill("Acrobatics", abilityscores[0]);
        a[0].AddSubskill("Jumping");
        a[0].AddSubskill("Balance");
        a[0].AddSubskill("Stunt");
        a[1] = new Skill("Animal Handling", abilityscores[4]);
        a[1].AddSubskill("Ride/Control");
        a[1].AddSubskill("Train");
        a[1].AddSubskill("Read Emotions");
        a[2] = new Skill("Arcana", abilityscores[3]);
        a[2].AddSubskill("Arcane Magic");
        a[2].AddSubskill("Aberrations");
        a[2].AddSubskill("Planes");
        a[2].AddSubskill("Dragons");
        a[2].AddSubskill("Constructs");
        a[2].AddSubskill("Magical Beasts");
        this.skills = a;

    }

    private void InitializeHome()
    {
        Home[] a = new Home[20];
        //a[0] = new Home();
    }

    private void RollAbilityScores()
    {
        AbilityScore[] a = abilityscores;
        a[0].SetScore(Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7));
        a[1].SetScore(Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7));
        a[2].SetScore(Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7));
        a[3].SetScore(Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7));
        a[4].SetScore(Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7));
        a[5].SetScore(Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7));
        this.c.SetScores(a);
    }

    private void DisplayScores()
    {
        AbilityScore[] a = this.c.GetScores();
        string s = a[0].GetName() + " " + a[0].GetScoreValue() + "\n";
        s += a[1].GetName() + " " + a[1].GetScoreValue() + "\n";
        s += a[2].GetName() + " " + a[2].GetScoreValue() + "\n";
        s += a[3].GetName() + " " + a[3].GetScoreValue() + "\n";
        s += a[4].GetName() + " " + a[4].GetScoreValue() + "\n";
        s += a[5].GetName() + " " + a[5].GetScoreValue() + "\n";
        this.displayscores.text = s;
        /*string s = this.c.GetScores()[0].name + " " + this.c.GetScores()[0].GetScore() + "\n";
        s += this.c.GetScores()[1].name + " " + this.c.GetScores()[1].GetScore() + "\n";
        s += this.c.GetScores()[2].name + " " + this.c.GetScores()[2].GetScore() + "\n";
        s += this.c.GetScores()[3].name + " " + this.c.GetScores()[3].GetScore() + "\n";
        s += this.c.GetScores()[4].name + " " + this.c.GetScores()[4].GetScore() + "\n";
        s += this.c.GetScores()[5].name + " " + this.c.GetScores()[5].GetScore() + "\n";*/
    /*}*/

    /*
private void StageOne()
{
    this.DisplayScores();
    string s = "Choose a score to replace with a 14";
    this.SetAbilityScoreChoiceButtons();
}

private void SetAbilityScoreChoiceButtons()
{
    int l = this.buttons.Length;
    Text t;
    for (int i = 0; i <l-1;i++)
    {
        t = this.buttons[i].GetComponentInChildren<Text>();
        t.text = this.c.GetScores()[i].GetName();
        int ac = i;
        this.buttons[i].onClick.AddListener(() => ReplaceScore(ref this.c.GetScores()[ac]));
    }
    t = this.buttons[l-1].GetComponentInChildren<Text>();
    t.text = "None";

}

private void ReplaceScore(ref AbilityScore a)
{
    a.SetScore(14);
    this.DisplayScores();
    for(int i = 0; i < this.buttons.Length; i++)
    {
        this.buttons[i].gameObject.SetActive(false);
    }
}

private void StageTwo()
{

}*/

}
