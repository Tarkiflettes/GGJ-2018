using System.Collections.Generic;
using cakeslice;
using UnityEngine;

public abstract class Trigger : RayReceiver
{
    public List<Triggered> TriggeredList;
    public List<Pickable> RequiredToTrigger;

    protected void Triggering()
    {
        foreach (var t in TriggeredList)
        {
            t.Action();
        }
    }

    protected abstract void Action();

    protected override void OnRayEnter()
    {
        // TODO bugguer
        var ol = GetComponent<Outline>();
        if (ol != null)
        {
            ol.color = 1;
        }
    }

    protected override void OnRaySelect()
    {
        if (!CanTrigger())
            return;
        OpenTrigger();
        Triggering();
        Action();
    }

    protected override void OnRayExit()
    {
        var ol = GetComponent<Outline>();
        if (ol != null)
        {
            ol.color = 2;
        }
    }

    // clear keys in the inventory that matches with RequiredToTrigger
    private void OpenTrigger()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            var p = player.GetComponent<Player>();
            foreach (var r in RequiredToTrigger)
            {
                p.Inventory.RemovePickable(r);
            }
        }
        RequiredToTrigger.Clear();
    }

    private bool CanTrigger()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var player in players)
        {
            var p = player.GetComponent<Player>();
            foreach (var r in RequiredToTrigger)
            {
                if (!p.Inventory.Contains(r))
                    return false;
            }
        }
        return true;
    }
}
