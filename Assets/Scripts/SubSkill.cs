using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSkill : MonoBehaviour
{

    public string subskillname;
    public int ranks;
    //public Skill skill;



    // Start is called before the first frame update
    void Start()
    {
        this.subskillname = this.name.ToLower();
        if (this.name.ToLower() != this.subskillname)
        {
            Debug.Log("Names unequal " + this.name + " " + this.subskillname);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
