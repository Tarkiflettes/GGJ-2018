using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigicodeLocker : Trigger {

    public string CodeSeeked;
    public string CodeEntered = "";
    private SafeButton[] _safeButtons;
    bool closed = true;

    // Use this for initialization
    void Start () {
        _safeButtons = GetComponentsInChildren<SafeButton>();

        foreach (var button in _safeButtons)
        {
            _safeButtons[11].Material = button.GetComponent<Renderer>().material;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (closed && checkPush())
        {
            _safeButtons[11].Material.SetColor("_Color", Color.green);
            Action();
            closed = false;
        }
    }

    bool checkPush()
    {
        if (_safeButtons[10].Pushed)
        {
            CodeEntered = "";
            _safeButtons[11].Material.SetColor("_Color", Color.white);
            resetButtons();
        }
        if (CodeEntered.Length < CodeSeeked.Length)
        {
            for (int i = 0; i < 10; i++)
            {
                if (_safeButtons[i].Pushed && !_safeButtons[i].TakenIntoAccount)
                {
                    CodeEntered += _safeButtons[i].Value;
                    _safeButtons[i].TakenIntoAccount = true;
                }
            }
        } else
        {
            Debug.Log(CodeEntered.Length);
            if (CodeEntered.Length == 4)
            {
                _safeButtons[11].Material.SetColor("_Color", Color.yellow);
            }
            if (_safeButtons[11].Pushed && CodeEntered == CodeSeeked)
            {
                resetButtons();
                return true;
            }
        }

        return false;
        
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
        Debug.Log("La porte doit s'ouvrir !");
        Triggering();
    }
}
