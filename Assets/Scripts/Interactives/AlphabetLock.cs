using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetLock : Trigger {

    public string CodeSeeked;
    public string Alphabet = "ABDCEFGHIJKLMNOPQRSTUVWXYZ";
    private CryptexCylinder[] _cryptexCylinder;
    bool closed = true;

    // Use this for initialization
    void Start () {
        _cryptexCylinder = GetComponentsInChildren<CryptexCylinder>();
        foreach (var j in _cryptexCylinder)
        {
            j.Size = Alphabet.Length;
        }
        locked = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (closed && checkWord())
        {
            Action();
            closed = false;
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
        locked = false;
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
