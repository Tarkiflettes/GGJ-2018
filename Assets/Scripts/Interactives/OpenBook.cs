using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : RayReceiver
{
    private bool open = false;
    private bool _busy = false;
    public float speed = 0.01f;

    private IEnumerator ContinuousRotationOpen()
    {
        for (var i = 0; i < 45; i++)
        {
            foreach (Transform child in GetComponentsInChildren<Transform>())
            {
                child.Rotate(Vector3.up, 2);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator ContinuousRotationClose()
    {
        for (var i = 0; i < 45; i++)
        {
            foreach (Transform child in GetComponentsInChildren<Transform>())
            {
                child.Rotate(Vector3.down, 2);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    protected void Action() {
        if (open)
        {
            _busy = true;
            StartCoroutine(ContinuousRotationOpen());
        } else
        {
            StartCoroutine(ContinuousRotationClose());
        }
        open = !open;
    }

    protected override void OnRayEnter()
    {
        
    }

    protected override void OnRaySelect()
    {
        Debug.Log("BookOpen");
        Action();
    }

    protected override void OnRayExit()
    {
        
    }
}
