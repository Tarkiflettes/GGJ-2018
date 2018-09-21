using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : RayReceiver
{
    private bool open = false;
    public float speed = 0.01f;

    public Rotator Rotator;

    public Vector3 Axis;

    protected void Action() {
        if (!open)
        {
            Rotator.Open(Axis, 65);
        } else
        {
            Rotator.Close();
        }
        open = !open;
    }

    protected override void OnRayEnter()
    {
        
    }

    protected override void OnRaySelect()
    {
        Debug.Log("Book open");
        Action();
    }

    protected override void OnRayExit()
    {
        
    }
}
