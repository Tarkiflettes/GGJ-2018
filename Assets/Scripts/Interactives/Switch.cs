using System.Collections;
using UnityEngine;

public class Switch : Trigger
{
    //private bool _busy = false;

    public Rotator Rotator;
    public Vector3 Axis;

    private bool turnedOn;

    protected override void Action()
    {
        if(!turnedOn)
        {
            Rotator.Open(Axis, 70);
        }
        else
        {
            Rotator.Close();
        }
        turnedOn = !turnedOn;
    }
}