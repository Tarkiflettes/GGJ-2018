using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMatrice : Trigger {

    private SwitchRoom2[] _switchButtons;
    private bool[] _correctMatrice = new bool[]{ false, true, false, false, true, false, false, false, false, false, false, true, false, false, true, false };
    private bool[] _currentMatrice = new bool[]{ false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };
    bool closed = true;

    protected override void Action()
    {
        Debug.Log("le tiroir s'ouvre !");
        Triggering();
    }

    // Use this for initialization
    void Start () {

        _switchButtons = GetComponentsInChildren<SwitchRoom2>();

    }

    // Update is called once per frame
    void Update () {
        if (closed && checkBool())
        {
            Action();
            closed = false;
        }
    }

    bool checkBool()
    {        
        for (int i = 0; i < _correctMatrice.Length; i++)
        {
            _currentMatrice[i] = _switchButtons[i].isTurnedOn;
            if (_correctMatrice[i] != _currentMatrice[i])
            {
                return false;
            }
        }
        return true;
    }
}
