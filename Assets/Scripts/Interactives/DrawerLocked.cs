using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerLocked : Triggered {

    public Drawer Drawer;

    public override void Action()
    {
        Drawer.SendMessage("ActionBase");
    }
}
