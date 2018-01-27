using UnityEngine;

public class Movable : RayReceiver {

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
