using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
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

    private CharacterLogicContainer character;

    public GameObject abilityScoreChoiceButtonPrefab;
    public GameObject menueCanvas;

    //public AbilityScores abilityscores;
    //public Skills skills;
    //public List<StartingLocation> startinglocations; 
    public Text displayscores;
    public Text displayskills;
    private GameObject[] buttons;
    private Button continueButton;
    private List<AbilityScore> tempStorage;


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

        character = new CharacterLogicContainer();
        this.tempStorage = new List<AbilityScore>();






        InitializeAbilityScores();
        InitializeSkills();
        InitializeHomeland();

        
        this.StageOneAbilityScores();
        //this.ChooseHome();
        Debug.Log(this.character.RandomHomeland());
        Display();

    }


    
    
    
    //This populates the ability scores
    private void InitializeAbilityScores()
    {
        Debug.Log("Initializing ability scores");
        //abilityscores = new AbilityScores();
        int end = abilityScoresJson.abilityScores.Count;
           

        for (int i = 0; i < end; i++)
        {
            Debug.Log("Initializing score: " + abilityScoresJson.abilityScores[i]);
            character.AddAbilityScore(abilityScoresJson.abilityScores[i], 10);
            
        }
        try
        {
            this.character.RollAbilityScores(3, 0, 6);
        } catch(RandomRollFailed ex)
        {
            Debug.Log(ex.Message);
            Debug.Log("Failed to roll ability scores");
        }
        
    }


    //This reads from the json files creates the character using the SkillTest classes created from the json files 
    private void InitializeSkills()
    {
        Debug.Log("Initializing skills");
        int skillEnd = skillsJson.skillTest.Count;
 
        for(int i = 0; i < skillEnd; i++)
        {
            
            try
            {
                if (skillsJson.skillTest[i].subskills != null)
                {
                    character.AddSkill(skillsJson.skillTest[i].name, skillsJson.skillTest[i].score, skillsJson.skillTest[i].subskills);
                }
                else
                {
                    List<string> sskl = new List<string>();
                    character.AddSkill(skillsJson.skillTest[i].name, skillsJson.skillTest[i].score, sskl);
                }

            } catch(ScoreNotFoundException ex)
            {
                Debug.Log(ex.Message);
                Debug.Log("Failed to initialize skill: " + skillsJson.skillTest[i].name);
            }
            
        }
    }

    private void InitializeHomeland()
    {
        Debug.Log("Initializing homeland");
        int i = 0;
        try
        {
            int end = this.homelandsJson.homelands.Count;
            //StartingLocation star;
            for (i = 0; i < end; i++)
            {
                character.AddHomeland(this.homelandsJson.homelands[i].home, this.homelandsJson.homelands[i].skill);
            }
        } catch(SkillNotFoundException ex)
        {
            Debug.Log(ex.Message);
            Debug.Log("Failed to initialize homeland: " + skillsJson.skillTest[i].name);
        }
    }



    private void DisplayScores()
    {
        Debug.Log("Displaying ability scores");

        string a = character.GetScoresAsString();
        this.displayscores.text = a;
    }

    private void DisplaySkills()
    {
        Debug.Log("Displaying skills");


        string a = character.GetSkillsAsString();
        this.displayskills.text = a;

    }

    private void Display()
    {
        this.DisplayScores();
        this.DisplaySkills();
    }

    private void StageOneAbilityScores()
    {
        Debug.Log("Stage 1");
        this.Display();
        int end = character.GetScoreSize();
        for(int i = 0; i < end; i++)
        {
            this.tempStorage.Add(this.character.GetScoreByIndex(i));
        }
        this.SetAbilityScoreChoiceButtons();
    }

    private void SetAbilityScoreChoiceButtons()
    {
        Debug.Log("Setting ability score choice buttons");
        //List<AbilityScore> s = abilityscores.GetScores();
        Text t;
        GameObject go;
        //AbilityScore score;
        RectTransform tr;
       

        int end = character.GetScoreSize();
        buttons = new GameObject[end+1];
        tr = GameObject.Find("Current Scores").GetComponent<RectTransform>();

        //creates the buttons that replace a score with 14
        for (int i = 0; i < end; i++)
        {
            // create the button and set the button's text to the ability score it represents
            go = Instantiate(abilityScoreChoiceButtonPrefab, tr.position, Quaternion.identity) as GameObject; 
            t = go.GetComponentInChildren<Text>();
            t.text = character.GetScoreByIndex(i).GetName();
            
            // add the button to the ui canvas and set its position on the canvas.
            go.transform.SetParent(tr);
            go.transform.position = new Vector3((tr.rect.width / 6.5f), tr.position.y-tr.rect.height/18 + end * 18 - i * 18, 0);
            
            // adds the button to the list for easy acess
            buttons[i] = go;

            //Add the component that is needed  
            string s = character.GetScoreByIndex(i).GetName();
            buttons[i].GetComponent<Button>().onClick.AddListener(()=> ReplaceScores(s));
        }

        //this makes the final button for when you don't want to replace a score 
        go = Instantiate(abilityScoreChoiceButtonPrefab, tr.position, Quaternion.identity) as GameObject;
        t = go.GetComponentInChildren<Text>();
        t.text = "none";
        go.transform.SetParent(tr);
        go.transform.position = new Vector3((tr.rect.width / 6.5f), tr.position.y - tr.rect.height / 18 + end * 18 - end * 18, 0);
        buttons[end] = go;
        buttons[end].GetComponent<Button>().onClick.AddListener(() => ReplaceScores());

        //t = this.buttons[end].GetComponentInChildren<Text>();
        //t.text = "None";

    }

    private void SwitchScores()
    {

    }
    
    private void ReplaceScores(string name)
    {
        character.GetScoreByName(name).SetScore(14);
        
        this.Display();

        for (int i = 0; i < this.buttons.Length; i++)
        {
            this.buttons[i].gameObject.SetActive(false);
        }
    }
    private void ReplaceScores()
    {
        this.Display();

        for (int i = 0; i < this.buttons.Length; i++)
        {
            this.buttons[i].gameObject.SetActive(false);
        }
    }


}







/*
private void ReplaceScores(ref AbilityScore a)
{
    a.SetScore(14);
    this.DisplayScores();
    for (int i = 0; i < this.buttons.Length; i++)
    {
        this.buttons[i].gameObject.SetActive(false);
    }
}
*/

/*
private void ChooseHome()
{
Debug.Log("Choosing a home");
int roll = Random.Range(0, this.startinglocations.Count); ;
this.skills.GetSkill(this.startinglocations[roll].GetLocation()).AddRanks(1);

Debug.Log(this.startinglocations[roll].GetSkill() + " " + this.startinglocations[roll].GetType());

}*/





/*
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
}*/


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

/*This rolls the scores
private void RollAbilityScores()
{
    Debug.Log("Rolling ability scores");
    int end = character.GetScoreSize();
    for (int i = 0; i < end; i++)
    {
        character.SetScoreByName(abilityscores.GetScores()[i].GetName(), RandomRoll(3, 0, 6));
        Debug.Log("Score: " + abilityscores.abilityScores[i].GetName() + ". Total: " + abilityscores.GetScores()[i].GetScore());
    }
    DisplayScores();
}*/
