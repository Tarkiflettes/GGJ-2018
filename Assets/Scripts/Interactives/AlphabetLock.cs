using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetLock : Trigger {

    public string CodeSeeked;
    public string Alphabet = "ABDCEFGHIJKLMNOPQRSTUVWXYZ";
    private CryptexCylinder[] _cryptexCylinder;
    bool opened = true;

    // Use this for initialization
    void Start () {
        _cryptexCylinder = GetComponentsInChildren<CryptexCylinder>();
	}
	
	// Update is called once per frame
	void Update () {
        if (opened && checkWord())
        {
            Action();
            opened = false;
        }
	}

    bool checkWord ()
    {
        foreach (var i in CodeSeeked)
        {
            foreach (var j in _cryptexCylinder)
            {
                if (i != getLetter(j))
                {
                    return false;
                }
            }
        }
        return true;
    }

    char getLetter(CryptexCylinder currentCylinder)
    {
        int currentStep = currentCylinder.Step % Alphabet.Length;
        return Alphabet[currentStep];
    }

    protected override void Action()
    {
        throw new System.NotImplementedException();
    }
}
