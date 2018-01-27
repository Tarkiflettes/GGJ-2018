using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightKitchen : Triggered
{
    private bool on = false;

    public override void Action()
    {
        if (on)
        {
            GetComponent<Renderer>().material.color = Color.clear;
        } else
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        on = !on;
    }

    public void Start()
    {
        GetComponent<Renderer>().material.color = Color.clear;
    }
}
