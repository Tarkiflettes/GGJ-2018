using System.Collections;
using UnityEngine;

public class Drawer : Trigger
{

    public bool Closed = true;
    public int Distance = 35;
    public Vector3 Axis;

    private int _closed = 1;
    private bool _busy = false;
    

    protected override void Action()
    {
        if (_busy)
        {
            return;
        }
        _busy = true;
        var openClose = OpenClose();
        StartCoroutine(openClose);
    }

    private IEnumerator OpenClose()
    {
        _closed = 1;
        if (Closed)
        {
            _closed = -1;
        }
        for (var i = 0; i < Distance; i++)
        {
            transform.Translate(Axis * Time.deltaTime * _closed, Space.World);
            yield return new WaitForSeconds(0.01f);
        }

        Closed = !Closed;
        _busy = false;
    }
}
