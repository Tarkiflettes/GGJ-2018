using System.Collections.Generic;
using UnityEngine;

public class LockScreenAction : RayReceiver
{
    public MeshCollider MajorCollider;
    public List<MeshCollider> Colliders;

    private bool ScreenLocked = false;

    // Update is called once per frame
    void Update()
    {

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

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        
        //MajorCollider.enabled = ScreenLocked;
        foreach (Collider col in Colliders)
        {
            col.enabled = !ScreenLocked;
        }
        ScreenLocked = !ScreenLocked;
    }
}
