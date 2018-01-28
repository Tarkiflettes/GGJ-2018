using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Placard : Trigger
{

    public Rotator Rotator;
    private bool _opened;
    public Vector3 Axis;

    [ContextMenu("Open")]
    protected override void Action()
    {
        if (!_opened)
        {
            Rotator.Open(Axis, 90);
        }
        else
        {
            Rotator.Close();
        }
        _opened = !_opened;
    }

}