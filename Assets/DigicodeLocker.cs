using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigicodeLocker : Trigger {

    public string CodeSeeked;
    public string CodeEntered;
    private SafeButton[] _safeButtons;
    bool closed = true;

    // Use this for initialization
    void Start () {
        _safeButtons = GetComponentsInChildren<SafeButton>();

    }
	
	// Update is called once per frame
	void Update () {
        if (closed && checkPush())
        {
            Action();
            closed = false;
        }
    }

    bool checkPush()
    {
        if (_safeButtons[10].Pushed)
        {
            CodeEntered = "";
            resetButtons();
        }
        if (CodeEntered.Length < CodeSeeked.Length)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_safeButtons[i].Pushed && !_safeButtons[i].TakenIntoAccount)
                {
                    CodeEntered += _safeButtons[i].Value;
                    _safeButtons[i].TakenIntoAccount = true;
                }
            }
        } else
        {
            //put validate in yellow _safeButtons[11].transform.
            if (_safeButtons[11].Pushed && CodeEntered != CodeSeeked)
            {
                resetButtons();
                return false;
            }
        }

        return true;
        
    }

    private void resetButtons()
    {
        foreach (var button in _safeButtons)
        {
            button.Pushed = false;
            button.TakenIntoAccount = false;
        }
    }

    protected override void Action()
    {
        throw new System.NotImplementedException();
    }
}
