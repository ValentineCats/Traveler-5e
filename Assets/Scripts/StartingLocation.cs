using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingLocation : MonoBehaviour
{
    Skill skill;


    public void Increase()
    {
        skill.AddRanks(0);
    }


}
