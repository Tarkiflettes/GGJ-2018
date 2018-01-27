using System.Collections.Generic;
using UnityEngine;

public class LockScreenAction : RayReceiver
{
    public List<MeshCollider> Colliders;

    //public Transform TransformOrigin { get { return _transformOrigin; } }
    [HideInInspector]
    public Vector3 _positionOrigin;
    [HideInInspector]
    public Quaternion _rotationOrigin;

    private bool ScreenLocked = false;

    private void Start()
    {
        _positionOrigin = transform.position;
        _rotationOrigin = transform.rotation;
        Debug.Log(transform.position);
    }

    //Overrides
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
        
        foreach (Collider col in Colliders)
        {
            col.enabled = !ScreenLocked;
        }
        ScreenLocked = !ScreenLocked;
    }
}
