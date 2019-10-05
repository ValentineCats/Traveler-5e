using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsOld2 : MonoBehaviour
{
    //string[] subskills;
    /*bool[] proficiencies;
    int[] ranks;
    string[] names;
    string[] scores;
    Hashtable[] skills;
    Hashtable[] subskills;*/


    //public Skill[] skills;

    private void Start()
    {
        
    }
















    /* Start is called before the first frame update
    void Start()
    {
        string[] s = new string[] { "acrobatics", "animal handing", "arcana", "athletics", "deception", "history", "insight", "intimidate", "investigation", "medicine", "nature", "perception"
        , "performance", "persuasion", "religion", "sleight of hand", "stealth", "saving throw", "mws", "rws", "ss", "tool proficiency", "vehicle proficiency"};
        string[] s2 = new string[] { "dex","wis", "int", "str", "cha", "int", "wis", "cha", "int", "wis", "int", "wis", "cha", "cha", "int", "dex", "dex", "str", "combat", "combat", "mental", "any", "dex" };
        int total = s.Length;
        names = s;
        scores = s2;
        proficiencies = new bool[total];
        ranks = new int[total];
        subskills = new Hashtable[total];
    }



    public int GetRank(string s)
    {
        return 1;
    }

    public int SkillIdByName(string s)
    {
        for (int i = 0; i < names.Length; i++)
        {
            
        }
        return 1;
    }



    private void MakeSkill(string n, string x , int i, Hashtable s)
    {
        proficiencies[i] = false;
        ranks[i] = 0;
        names[i] = n;
        subskills[i] = s;
        scores[i] = x;
    }




    private void TempGenSubskills()
    {
        Hashtable a = new Hashtable();
        a.Add("jumping", 0);
        a.Add("balance", 0);
        a.Add("stunt", 0);
        a.Add("escape", 0);
        subskills[0] = a;
        a = new Hashtable();
        a.Add("ride", 0);
        a.Add("train", 0);
        a.Add("read emotions", 0);
        subskills[1] = a;
        a = new Hashtable();
        a.Add("arcane magic", 0);
        a.Add("aberrations", 0);
        a.Add("planes", 0);
        a.Add("dragons", 0);
        a.Add("construct", 0);
        a.Add("magical beasts", 0);
        subskills[2] = a;
        a = new Hashtable();
        a.Add("climb", 0);
        a.Add("jump", 0);
        a.Add("swim", 0);
        a.Add("grapple", 0);
        subskills[3] = a;
        a = new Hashtable();
        a.Add("lies", 0);
        a.Add("disguise", 0);
        a.Add("forgery", 0);
        subskills[4] = a;
        a = new Hashtable();
        a.Add("people", 0);
        a.Add("events", 0);
        a.Add("locations", 0);
        a.Add("laws", 0);
        a.Add("humanoids", 0);
        subskills[5] = a;
        a = new Hashtable();
        a.Add("detect lies", 0);
        a.Add("intentions", 0);
        a.Add("emotions", 0);
        subskills[6] = a;
        a = new Hashtable();
        a.Add("scare", 0);
        a.Add("inspire", 0);
        a.Add("extort", 0);
        subskills[7] = a;
        a = new Hashtable();
        a.Add("deduction", 0);
        a.Add("hidden object", 0);
        a.Add("crime scenes", 0);
        a.Add("forgery", 0);
        subskills[8] = a;
        a = new Hashtable();
        a.Add("injury", 0);
        a.Add("diseases", 0);
        a.Add("poisons", 0);
        subskills[9] = a;
        a = new Hashtable();
        a.Add("beasts", 0);
        a.Add("weather", 0);
        a.Add("fey", 0);
        a.Add("plant", 0);
        a.Add("monstrous", 0);
        subskills[10] = a;
        a = new Hashtable();
        a.Add("see", 0);
        a.Add("hear", 0);
        a.Add("feel", 0);
        a.Add("smell", 0);
        subskills[11] = a;
        a = new Hashtable();
        a.Add("act", 0);
        a.Add("dance", 0);
        a.Add("song", 0);
        a.Add("inspire", 0);
        subskills[12] = a;
        a = new Hashtable();
        a.Add("trade", 0);
        a.Add("diplomacy", 0);
        a.Add("befriend/seduce", 0);
        a.Add("oration", 0);
        subskills[13] = a;
        a = new Hashtable();
        a.Add("undead", 0);
        a.Add("fiends", 0);
        a.Add("celestials", 0);
        a.Add("religions", 0);
        a.Add("divine magic", 0);
        subskills[14] = a;
        a = new Hashtable();
        a.Add("pickpocketing", 0);
        a.Add("concealed carry", 0);
        a.Add("lock picking", 0);
        subskills[15] = a;
        a = new Hashtable();
        a.Add("hide", 0);
        a.Add("move silently", 0);
        a.Add("stow items", 0);
        subskills[16] = a;
        a = new Hashtable();
        a.Add("gather food", 0);
        a.Add("track", 0);
        a.Add("pathfinder", 0);
        a.Add("poisons", 0);
        a.Add("natural hazards", 0);
        subskills[17] = a;
        a = new Hashtable();
        a.Add("str", 0);
        a.Add("dex", 0);
        a.Add("con", 0);
        a.Add("int", 0);
        a.Add("wis", 0);
        a.Add("cha", 0);
        subskills[18] = a;
        a = new Hashtable();
        a.Add("hammers/maces", 0);
        a.Add("blades", 0);
        a.Add("spears", 0);
        a.Add("axes", 0);
        a.Add("improvised", 0);
        a.Add("exotic", 0);
        subskills[19] = a;
        a = new Hashtable();
        a.Add("bows", 0);
        a.Add("crossbows", 0);
        a.Add("slings", 0);
        a.Add("thrown", 0);
        subskills[20] = a;
        a = new Hashtable();
        a.Add("ranged", 0);
        a.Add("melee", 0);
        a.Add("save", 0);
        subskills[21] = a;
        a = new Hashtable();
        a.Add("thieve's", 0);
        a.Add("blacksmith's", 0);
        a.Add("fletcher's", 0);
        a.Add("bowyer's", 0);
        a.Add("calligrapher's", 0);
        a.Add("painter's", 0);
        a.Add("sculptor's", 0);
        a.Add("navigator's", 0);
        a.Add("siege", 0);
        a.Add("artillery", 0);
        a.Add("gambling kit", 0);
        a.Add("card game kit", 0);
        a.Add("board game kit", 0);
        a.Add("any instrument", 0);
        subskills[22] = a;
        a = new Hashtable();
        a.Add("small vessels", 0);
        a.Add("medium vessels", 0);
        a.Add("large vessels", 0);
        a.Add("carts/carriages", 0);
        a = new Hashtable();
    }*/





}
