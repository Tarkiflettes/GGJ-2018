using Assets.Scripts.Interactives;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presure_place : Trigger {
    protected override void Action()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
    }

    private void OnTriggerExit(Collider collider)
    {
        
    }
}
