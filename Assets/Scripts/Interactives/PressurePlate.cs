﻿using UnityEngine;

public class PressurePlate : Trigger {

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
