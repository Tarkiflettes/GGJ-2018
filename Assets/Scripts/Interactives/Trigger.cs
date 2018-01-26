using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : RayReceiver
{
    public List<Triggered> TriggeredList;

    void Action()
    {
        foreach (var t in TriggeredList)
        {
            t.Action();
        }
    }

    protected override void OnRayEnter()
    {
    }

    protected override void OnRaySelect()
    {
        Action();
    }

    protected override void OnRayExit()
    {
    }
}
