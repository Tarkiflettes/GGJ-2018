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
        if(collider.name == "Character")
        {
            Triggering();
            transform.position += new Vector3(0, 0.5f, 0);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.name == "Character")
        {
            transform.position += new Vector3(0, -0.5f, 0);
        }
    }
}
