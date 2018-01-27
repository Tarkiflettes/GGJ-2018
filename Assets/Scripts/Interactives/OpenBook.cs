using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : Trigger
{
    protected override void Action()
    {
        foreach (Transform child in transform.parent)
        {
            Debug.Log(child.name + " : " +  child.eulerAngles);
            child.eulerAngles = new Vector3(child.eulerAngles.x+45 , child.eulerAngles.y+90, child.eulerAngles.z+90);
        }
    }
}
