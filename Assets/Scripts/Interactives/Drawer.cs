using System.Collections;
using UnityEngine;

public class Drawer : Triggered
{

    public bool Closed = true;
    public int Length = 50;

    private int _closed = 1;
    private bool _busy = false;

    public override void Action()
    {
        if (_busy) return;

        _busy = true;
        var openClose = OpenClose();
        StartCoroutine(openClose);
    }

    private IEnumerator OpenClose()
    {
        _closed = 1;
        if (Closed)
            _closed = -1;

        for (var i = 0; i < 90; i++)
        {
            transform.Rotate(Vector3.forward, _closed);
            yield return new WaitForSeconds(0.01f);
        }

        Closed = !Closed;
        _busy = false;
    }
}
