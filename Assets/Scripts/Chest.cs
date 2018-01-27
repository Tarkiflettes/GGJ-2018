using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Triggered {

    public Rotator Rotator;
    private bool _opened;

    [ContextMenu("Open")]
    public override void Action()
    {
        if(!_opened)
        {
            Rotator.Open(Vector3.left, 50);
        } else
        {
            Rotator.Close();
        }
        _opened = !_opened;
    }
}
