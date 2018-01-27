using Assets.Scripts.Interactives;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Trigger {

    protected override void Action()
    {
        transform.Rotate(90, 0, 0);
    }

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

        //Quaternion.FromToRotation(Vector3.right, transform.forward);


    }
}
