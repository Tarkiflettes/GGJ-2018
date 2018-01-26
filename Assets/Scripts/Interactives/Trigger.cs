using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public List<Triggered> TriggeredList;
    
    void Start()
    {
        TriggeredList = new List<Triggered>();
    }

    void Action()
    {
        foreach (var t in TriggeredList)
        {
            t.Action();
        }
    }

}
