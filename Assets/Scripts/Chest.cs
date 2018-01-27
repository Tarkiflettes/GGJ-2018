using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Triggered {

    public Rotator Rotator;
    private bool opened;

    [ContextMenu("Open")]
    public override void Action()
    {
        if(!opened)
        {
            Rotator.Open(Vector3.left, 50);
        } else
        {
            Rotator.Close();
        }
        opened = !opened;
    }
}
