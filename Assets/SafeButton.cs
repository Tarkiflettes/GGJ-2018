using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeButton : RayReceiver {

    public string Value;
    public bool Pushed = false;
    public bool TakenIntoAccount = false;
    public Color Color = Color.grey; 
    public Material Material;

    protected override void OnRayEnter()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color);
    }

    protected override void OnRayExit()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }

    protected override void OnRaySelect()
    {
        onPush();
    }

    void onPush()
    {
        Pushed = true;
    }
}
