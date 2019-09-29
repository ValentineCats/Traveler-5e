using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class Dummy
{
    public int x;
    public string stringythingy;
}
public class TestButtonBhavior : MonoBehaviour
{

    public Button testButton;
    // Start is called before the first frame update
    void Start()
    {
        testButton.onClick.AddListener(Test("newName"));

        var t = new Dummy();

        t.x = 5;
        t.stringythingy = "wowweeee!";


        var x = Newtonsoft.Json.JsonSerializer.Create();
        var tr = new System.IO.StringWriter();
        x.Serialize(tr, t);
        var m = x.ToString();
        Debug.Log(m);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    UnityEngine.Events.UnityAction Test(string a)
    {
        return () => testButton.GetComponentInChildren<Text>().text = a;


    }
}
