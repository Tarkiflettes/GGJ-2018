using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouton : RayReceiver {

    protected override void OnRayEnter()
    {
        Debug.Log("OHOHO");
    }

    protected override void OnRayExit()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnRaySelect()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
