using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Placard : Triggered
{

    public Rotator rotator;
    private bool _busy = false;
    private bool on = false;

    private IEnumerator ContinuousRotation(Vector3 vector)
    {
        for (var i = 0; i < 90; i++)
        {
            transform.Rotate(vector, 1);
            yield return new WaitForSeconds(0.01f);
        }
        _busy = false;
    }

    [ContextMenu("Open")]
    public override void Action()
    {
        var vector = Vector3.up;

        Debug.Log(transform.rotation);

        if (on)
        {
            vector = Vector3.down;
        }

        if (!_busy)
        {
            _busy = true;
            on = !on;
            var continuousRotation = ContinuousRotation(vector);
            StartCoroutine(continuousRotation);
        }
    }

}