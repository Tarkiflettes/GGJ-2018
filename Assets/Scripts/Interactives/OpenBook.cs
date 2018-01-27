using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : Trigger
{
    private bool open = false;
    private bool _busy = false;
    public float speed = 0.01f;

    private IEnumerator ContinuousRotation()
    {
        
        for (var i = 0; i < (int)(45/speed); i++)
        {
            foreach (Transform child in transform.parent)
            {
                if (!open)
                    child.Rotate(Vector3.down, speed);
                else
                    child.Rotate(Vector3.up, speed);
            }
                yield return new WaitForSeconds(0.1f);
        }
        _busy = false;
        open = !open;
    }

    protected override void Action()
    {
        if (!_busy)
        {
            _busy = true;
            var rotate = ContinuousRotation();
            StartCoroutine(rotate);
        }
    }
}
