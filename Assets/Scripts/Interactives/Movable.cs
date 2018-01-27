using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : RayReceiver {
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnRayEnter()
    {
        Debug.Log("OnEnter");
    }

    protected override void OnRayExit()
    {
        Debug.Log("OnExit");
    }

    protected override void OnRaySelect()
    {
        Debug.Log("OnSelect");
    }
}
