using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRoom2 : RayReceiver {

    //private bool _busy = false;

    public Rotator Rotator;
    public Vector3 Axis;

    public bool isTurnedOn;

    void onAction()
    {
        if (!isTurnedOn)
        {
            Rotator.Open(Axis, 70);
        }
        else
        {
            Rotator.Close();
        }
        isTurnedOn = !isTurnedOn;
    }

    protected override void OnRayEnter()
    {
    }

    protected override void OnRayExit()
    {
    }

    protected override void OnRaySelect()
    {
        onAction();
    }
}
