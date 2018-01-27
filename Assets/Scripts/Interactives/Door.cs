using System.Collections;
using UnityEngine;

public class Door : Triggered
{

    public bool Direction = true;
    public bool Closed = true;

    private int _closed = 1;
    private bool _busy = false;

    void Start()
    {
        var direction = 90;
        if (!Direction)
            direction = -90;
        if (Closed)
            transform.rotation = Quaternion.Euler(0, direction, 0);
    }

    private IEnumerator ContinuousRotation()
    {
        _closed = 1;
        if (Closed)
            _closed = -1;

        for (var i = 0; i < 90; i++)
        {
            if (Direction)
                transform.Rotate(Vector3.down, _closed);
            else
                transform.Rotate(Vector3.up, _closed);
            yield return new WaitForSeconds(0.01f);
        }

        Closed = !Closed;
        _busy = false;
    }

    public override void Action()
    {
        if (_busy) return;

        _busy = true;
        var continuousRotation = ContinuousRotation();
        StartCoroutine(continuousRotation);
    }

}
