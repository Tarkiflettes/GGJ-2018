using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetLock : Trigger {

    public string CodeSeeked;
    public string Alphabet = "ABDCEFGHIJKLMNOPQRSTUVWXYZ";
    private CryptexCylinder[] _cryptexCylinders;
    bool closed = true;

    // Use this for initialization
    void Start () {
        _cryptexCylinders = GetComponentsInChildren<CryptexCylinder>();
        foreach (var j in _cryptexCylinders)
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
        int index = 0;
        foreach (var elemLocker in CodeSeeked)
        {
            if (elemLocker != getLetter(_cryptexCylinders[index]))
            {
                return false;
            }
            index++;
        }
        //locked = false;
        return true;
    }

    char getLetter(CryptexCylinder currentCylinder)
    {
        // (a % b + b) % b
        int currentStep = (currentCylinder.Step % Alphabet.Length + Alphabet.Length) % Alphabet.Length;
        //int currentStep = currentCylinder.Step % Alphabet.Length;
        return Alphabet[currentStep];
    }

    protected override void Action()
    {
        Triggering();
    }
}
