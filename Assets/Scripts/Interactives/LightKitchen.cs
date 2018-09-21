using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightKitchen : Triggered
{
    private bool on = false;
    public int etat = 0;

    public override void Action()
    {
        if(etat == 0)
        {
            if (on)
            {
                GetComponent<Renderer>().material.color = Color.clear;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else
        {
            if (on)
            {
                GetComponent<Renderer>().material.color = Color.clear;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.blue;
            }
        }
        
        on = !on;
    }

    public void Start()
    {
        if(etat == 0)
        {
            GetComponent<Renderer>().material.color = Color.clear;
        } else
        {
            GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
