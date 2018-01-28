using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier : Trigger {

    public Rotator Rotator;
    public Vector3 Axis;

    private bool open;

    protected override void Action()
    {
        if (!open)
        {
            Rotator.Open(Axis, 25);
        }
        else
        {
            Rotator.Close();
        }
        open = !open;
    }
}
