using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeButton : MonoBehaviour {

    public string Value;
    public bool Pushed = false;
    public bool TakenIntoAccount = false;

    void onPush()
    {
        Pushed = true;
    }
}
