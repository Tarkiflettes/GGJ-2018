using System.Collections;
using UnityEngine;

public class Switch : Trigger
{
    private bool _busy = false;

    private IEnumerator ContinuousRotation(Vector3 vector)
    {
        for (var i = 0; i < 45; i++)
        {
            transform.Rotate(vector, 1);
            yield return new WaitForSeconds(0.01f);
        }
        _busy = false;
    }

    protected override void Action()
    {
        var vector = Vector3.forward;

        if (transform.rotation == Quaternion.Euler(0, 0, 45))
        {
            vector = Vector3.back;
        }

        if (!_busy)
        {
            _busy = true;
            var continuousRotation = ContinuousRotation(vector);
            StartCoroutine(continuousRotation);
        }
    }

}