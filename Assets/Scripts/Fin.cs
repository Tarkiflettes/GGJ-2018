using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin : Triggered {
    public override void Action()
    {
        Application.Quit();
    }


}
